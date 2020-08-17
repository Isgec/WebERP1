Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Ionic
Imports Ionic.Zip
Imports System.Net
Partial Class GF_ReportTPTBill
  Inherits SIS.SYS.GridBase
  Private st As Integer = HttpContext.Current.Server.ScriptTimeout
  Private Sub PrintPOCard_Click(sender As Object, e As EventArgs) Handles PrintPOCard.Click
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim PONo As String = F_PONumber.Text
    If PONo = "" Then Return
    Dim TemplateName As String = "PO_Template.xlsx"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
    IO.File.Copy(tmpFile, FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
    Dim r As Integer = 4
    Dim c As Integer = 1
    Dim cnt As Integer = 1
    Dim DownloadName As String = PONo

    Dim POWt As Double = VRs.GetPOWt(PONo)

    xlWS.Cells(4, 2).Value = PONo
    xlWS.Cells(4, 3).Value = POWt


    Dim tmpVRs As List(Of VRs) = VRs.GetPOVrs(PONo)
    For Each tmp As VRs In tmpVRs
      With xlWS
        c = 4
        .Cells(r, c).Value = tmp.RequestNo
        c += 1
        .Cells(r, c).Value = tmp.TruckCapacity
        c += 1
        .Cells(r, c).Value = tmp.MaterialWt
        c += 1
        .Cells(r, c).Value = tmp.MaterialDimention
        c += 1
        .Cells(r, c).Value = tmp.Remarks
      End With
      r += 1
    Next




    xlPk.Save()
    xlPk.Dispose()

    If Convert.ToBoolean(ConfigurationManager.AppSettings("PDFReport")) Then
      If pdfWriter.generateXLPDF(FileName) Then
        DownloadName = DownloadName & ".PDF"
        FileName = FileName & ".PDF"
      Else
        DownloadName = DownloadName & ".xlsx"
      End If
    Else
      DownloadName = DownloadName & ".xlsx"
    End If

    Response.Clear()
    Response.Cache.SetCacheability(HttpCacheability.NoCache)
    Response.AppendHeader("content-disposition", "attachment; filename=" & DownloadName)
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(DownloadName)
    Response.WriteFile(FileName)
    Dim x As New System.Web.HttpCookie("fileDownload", "true")
    x.Path = "/"
    Response.AppendCookie(x)
    Response.Flush()
    HttpContext.Current.Server.ScriptTimeout = st
    Response.End()

  End Sub

  Private Sub TBLerpCreateTPTBill_Init(sender As Object, e As EventArgs) Handles TBLerpCreateTPTBill.Init
    SetToolBar = TBLerpCreateTPTBill
  End Sub
  Private Class VRs
    Public Property RequestNo As Integer = 0
    Public Property TruckCapacity As Decimal = 0
    Public Property MaterialWt As Decimal = 0
    Public Property MaterialDimention As String = ""
    Public Property Remarks As String = ""

    Public Shared Function GetPOWt(PONO As String) As Decimal
      Dim mRet As Decimal = 0
      Dim Sql As String = ""
      Sql &= " select "
      Sql &= " isnull(sum(case when t_cuqp='mt' then t_qoor*1000 else t_qoor end),0) as tmp "
      Sql &= " From ttdpur401200 "
      Sql &= "  Where t_cuqp In ('kg','mt') "
      Sql &= " And t_orno ='" & PONO & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
    End Function

    Public Shared Function GetPOVrs(PONO As String, Optional prj As String = "") As List(Of VRs)
      Dim mRet As New List(Of VRs)
      Dim Sql As String = ""
      Sql &= " select "
      Sql &= " vr.RequestNo As RequestNo, "
      Sql &= " 'L '+LTRIM(str(vr.length))+', W '+ltrim(str(vr.width))+', H '+ltrim(str(vr.height)) as MaterialDimention, "
      Sql &= " (case when vr.weightunit=3 then vr.materialweight*1000 else vr.materialweight end) As MaterialWt, "
      Sql &= " vt.capacityinkg as TruckCapacity, "
      Sql &= " vr.Remarks As Remarks "
      Sql &= " From vr_vehiclerequest As vr "
      Sql &= " inner Join vr_requestExecution As re On re.srnno=vr.srnno "
      Sql &= " inner Join vr_vehicletypes as vt on re.vehicletypeid=vt.vehicletypeid "
      Sql &= " where 1 = 1 "
      If PONO <> "" Then
        Sql &= " and vr.erpponumber ='" & PONO & "'"
      End If
      If prj <> "" Then
        Sql &= " and vr.projectid ='" & prj & "'"
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            mRet.Add(New VRs(Reader))
          End If
          Reader.Close()
        End Using
      End Using
      Return mRet
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Sub New()
      'dummy
    End Sub
  End Class
End Class
