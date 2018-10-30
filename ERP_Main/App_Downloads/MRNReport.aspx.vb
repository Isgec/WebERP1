Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Drawing

Partial Class MRNReport
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    Dim FromDate As String = ""
    Dim ToDate As String = ""
    Dim Project As String = ""
    Try
      FromDate = Request.QueryString("fd")
      ToDate = Request.QueryString("td")
      Project = Request.QueryString("typ")
    Catch ex As Exception
      FromDate = ""
      ToDate = ""
      Project = ""
    End Try
    If FromDate = String.Empty Then Return
    Dim DWFile As String = "MRN Report"
    Dim FilePath As String = CreateFile(FromDate, ToDate, Project)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String, ByVal project As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\MRNTemplate.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
    Dim oDocs As List(Of MRNReportClass) = MRNReportClass.GetData(FromDate, ToDate, project)
    Dim r As Integer = 5
    Dim c As Integer = 2
    Dim s As Integer = 1
    Dim identifier As String = ""
    'xlWS.Cells(2, 2).Value = Now
    xlWS.Cells(3, 2).Value = "MRN Report From " & FromDate & " TO " & ToDate
    With xlWS
      For Each doc As MRNReportClass In oDocs
        If r > 5 Then
          xlWS.InsertRow(r, 1, r + 1)
        End If
        c = 2

        If identifier <> doc.Projectno Then
          .Cells(r, 2).Value = s

          'xlWS.Cells(r, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
          'xlWS.Cells(r, 2).Style.Fill.BackgroundColor.SetColor(Color.Orange)
          s = s + 1
          'c = c + 1
          .Cells(r, 3).Value = doc.Description
          'xlWS.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
          'xlWS.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(Color.Orange)
          'c = c + 1
          .Cells(r, 4).Value = doc.MRNNo
          'c = c + 1
          .Cells(r, 5).Value = doc.SerialNo
          'c = c + 1
          .Cells(r, 6).Value = doc.MRNDate
          'c = c + 1
          .Cells(r, 7).Value = doc.LRStatusID
          'c = c + 1
          .Cells(r, 8).Value = doc.MRNStatus
          'c = c + 1
          .Cells(r, 9).Value = doc.GRorLRNo
          'c = c + 1
          .Cells(r, 10).Value = doc.GRorLRDate
          'c = c + 1
          .Cells(r, 11).Value = doc.VehicleRegistrationNo
          'c = c + 1


          .Cells(r, 12).Value = doc.TransporterID
          c = c + 1

          .Cells(r, 13).Value = doc.TransporterName
          'c = c + 1
          .Cells(r, 14).Value = doc.RemarksForDamageOrShortage
          'c = c + 1


          .Cells(r, 15).Value = doc.MaterialStateID
          'c = c + 1
          .Cells(r, 26).Value = doc.WeightAsPerInvoiceInKG
        Else
          'c = c + 1
          .Cells(r, 2).Value = ""
          'c = c + 1
          .Cells(r, 3).Value = ""
          'c = c + 1
          .Cells(r, 4).Value = ""
          'c = c + 1
          .Cells(r, 5).Value = ""
          'c = c + 1
          .Cells(r, 6).Value = ""
          'c = c + 1
          .Cells(r, 7).Value = ""
          'c = c + 1
          .Cells(r, 8).Value = ""
          'c = c + 1
          .Cells(r, 9).Value = ""
          'c = c + 1
          .Cells(r, 10).Value = ""
          'c = c + 1
          '.Cells(r, c).Value = doc.ConsigneeGSTIN
          'c = c + 1
          .Cells(r, 11).Value = ""
          'c = c + 1
          '.Cells(r, c).Value = doc.ConsigneeAddress2Line
          'c = c + 1
          '.Cells(r, c).Value = doc.ConsigneeAddress3Line
          'c = c + 1
          '.Cells(r, c).Value = doc.ConsigneeStateID
          'c = c + 1
          .Cells(r, 12).Value = ""
          'c = c + 1
          .Cells(r, 13).Value = ""
          'c = c + 1
          .Cells(r, 14).Value = ""
          'c = c + 1
          .Cells(r, 15).Value = ""
          .Cells(r, 26).Value = ""
          'r = r + 1

        End If
        'xlWS.Cells(r, 16).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 16).Style.Fill.BackgroundColor.SetColor(Color.LightYellow)
        'c = c + 1
        .Cells(r, 16).Value = doc.WeightReceived
        'c = c + 1
        .Cells(r, 17).Value = doc.MaterialStatus
        'c = c + 1
        .Cells(r, 18).Value = doc.SupplierInvoiceNo
        'c = c + 1
        .Cells(r, 19).Value = doc.SupplierInvoiceDate
        'c = c + 1

        'c = c + 1
        .Cells(r, 20).Value = doc.SupplierID
        'c = c + 1
        .Cells(r, 21).Value = doc.SupplierName
        'c = c + 1

        identifier = doc.Projectno
        r += 1

      Next
    End With


    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
  Private Function RemoveChars(ByVal mstr As String) As String
    'Dim tstr As String = ""
    'For i As Integer = 0 To mstr.Length - 1
    '	If Asc(mstr.Chars(i)) Then

    '	End If
    'Next
    Return mstr.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbNewLine, "")
  End Function
End Class
Public Class MRNReportClass

  Private _Projectno As String = ""
  Public Property Projectno() As String
    Get
      Return _Projectno
    End Get
    Set(ByVal value As String)
      _Projectno = value
    End Set
  End Property
  Private _Description As String = ""
  Public Property Description() As String
    Get
      Return _Description
    End Get
    Set(ByVal value As String)
      _Description = value
    End Set
  End Property


  Private _MRNNo As String = ""
  Public Property MRNNo() As String
    Get
      Return _MRNNo
    End Get
    Set(ByVal value As String)
      _MRNNo = value
    End Set
  End Property


  Private _SerialNo As String = ""
  Public Property SerialNo() As String
    Get
      Return _SerialNo
    End Get
    Set(ByVal value As String)
      _SerialNo = value
    End Set
  End Property


  Private _MRNDate As String = ""
  Public Property MRNDate() As String
    Get
      Return _MRNDate
    End Get
    Set(ByVal value As String)
      _MRNDate = value
    End Set
  End Property

  Private _LRStatusID As String = ""
  Public Property LRStatusID() As String
    Get
      Return _LRStatusID
    End Get
    Set(ByVal value As String)
      _LRStatusID = value
    End Set
  End Property


  Private _MRNStatus As String = ""
  Public Property MRNStatus() As String
    Get
      Return _MRNStatus
    End Get
    Set(ByVal value As String)
      _MRNStatus = value
    End Set
  End Property

  Private _GRorLRNo As String = ""
  Public Property GRorLRNo() As String
    Get
      Return _GRorLRNo
    End Get
    Set(ByVal value As String)
      _GRorLRNo = value
    End Set
  End Property


  Private _GRorLRDate As String = ""
  Public Property GRorLRDate() As String
    Get
      Return _GRorLRDate
    End Get
    Set(ByVal value As String)
      _GRorLRDate = value
    End Set
  End Property

  Private _VehicleRegistrationNo As String = ""
  Public Property VehicleRegistrationNo() As String
    Get
      Return _VehicleRegistrationNo
    End Get
    Set(ByVal value As String)
      _VehicleRegistrationNo = value
    End Set
  End Property


  Private _TransporterID As String = ""
  Public Property TransporterID() As String
    Get
      Return _TransporterID
    End Get
    Set(ByVal value As String)
      _TransporterID = value
    End Set
  End Property
  Private _TransporterName As String = ""
  Public Property TransporterName() As String
    Get
      Return _TransporterName
    End Get
    Set(ByVal value As String)
      _TransporterName = value
    End Set
  End Property


  Private _RemarksForDamageOrShortage As String = ""
  Public Property RemarksForDamageOrShortage() As String
    Get
      Return _RemarksForDamageOrShortage
    End Get
    Set(ByVal value As String)
      _RemarksForDamageOrShortage = value
    End Set
  End Property

  Private _MaterialStateID As String = ""
  Public Property MaterialStateID() As String
    Get
      Return _MaterialStateID
    End Get
    Set(ByVal value As String)
      _MaterialStateID = value
    End Set
  End Property


  Private _WeightAsPerInvoiceInKG As String = ""
  Public Property WeightAsPerInvoiceInKG() As String
    Get
      Return _WeightAsPerInvoiceInKG
    End Get
    Set(ByVal value As String)
      _WeightAsPerInvoiceInKG = value
    End Set
  End Property


  Private _WeightReceived As String = ""
  Public Property WeightReceived() As String
    Get
      Return _WeightReceived
    End Get
    Set(ByVal value As String)
      _WeightReceived = value
    End Set
  End Property


  Private _MaterialStatus As String = ""
  Public Property MaterialStatus() As String
    Get
      Return _MaterialStatus
    End Get
    Set(ByVal value As String)
      _MaterialStatus = value
    End Set
  End Property

  Private _SupplierInvoiceNo As String = ""
  Public Property SupplierInvoiceNo() As String
    Get
      Return _SupplierInvoiceNo
    End Get
    Set(ByVal value As String)
      _SupplierInvoiceNo = value
    End Set
  End Property


  Private _SupplierInvoiceDate As String = ""
  Public Property SupplierInvoiceDate() As String
    Get
      Return _SupplierInvoiceDate
    End Get
    Set(ByVal value As String)
      _SupplierInvoiceDate = value
    End Set
  End Property
  Private _SupplierID As String = ""
  Public Property SupplierID() As String
    Get
      Return _SupplierID
    End Get
    Set(ByVal value As String)
      _SupplierID = value
    End Set
  End Property


  Private _SupplierName As String = ""
  Public Property SupplierName() As String
    Get
      Return _SupplierName
    End Get
    Set(ByVal value As String)
      _SupplierName = value
    End Set
  End Property






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
  Public Sub New()
  End Sub
  Public Shared Function GetData(ByVal FromDate As String, ByVal ToDate As String, ByVal project As String) As List(Of MRNReportClass)
    Dim Sql As String = ""
    Sql &= "  SELECT "
    Sql &= "   * "
    Sql &= "   FROM VR_MRN_Report"
    Sql &= "  WHERE"
    Sql &= "  ([MRNDate] >= convert(datetime,'" & FromDate & "', 103)  AND [MRNDate] <= convert(datetime,'" & ToDate & "', 103))"
    Sql &= "  and [ProjectID] =" & project & ""
    ' Sql &= "  ORDER BY [ChallanDate]"

    Return GetMRNReportClass(Sql)
  End Function
  Private Shared Function GetMRNReportClass(ByVal Sql As String) As List(Of MRNReportClass)
    Dim Results As List(Of MRNReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 1200
        Results = New List(Of MRNReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New MRNReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results

  End Function

End Class
