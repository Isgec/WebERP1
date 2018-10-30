Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Drawing

Partial Class ITMonthlyReport
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    Dim FMonth As String = ""
    Try
      FMonth = Request.QueryString("fd")
    Catch ex As Exception
      FMonth = ""
    End Try
    If FMonth = String.Empty Then Return
    Dim DWFile As String = "IT Monthly Report" & FMonth
    Dim FilePath As String = CreateFile(FMonth)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub

  Private Function CreateFile(ByVal FMon As String) As String
    Dim ToDate As String = ""
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\ITTemplate.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

    'MRN -1
    Dim xlWS1 As ExcelWorksheet = xlPk.Workbook.Worksheets("MRN")
    Dim x1 As MRNData = MRNData.GetMRNData(FMon)
    Dim d1 As MRNData.DateObj = MRNData.GetDateObj(FMon)
    With xlWS1

      .Cells(1, 1).Value = "MRN(Created on site)"
      .Cells(1, 2).Value = MonthName(d1.ll_FromDate.Month)
      .Cells(1, 3).Value = MonthName(d1.l_FromDate.Month)
      .Cells(1, 4).Value = MonthName(d1.c_FromDate.Month)

      .Cells(2, 1).Value = "BOILER"
      .Cells(2, 2).Value = x1.BoilerLL
      .Cells(2, 3).Value = x1.BoilerLM
      .Cells(2, 4).Value = x1.BoilerCM

      .Cells(3, 1).Value = "SMD"
      .Cells(3, 2).Value = x1.SMDLL
      .Cells(3, 3).Value = x1.SMDLM
      .Cells(3, 4).Value = x1.SMDCM

      .Cells(4, 1).Value = "EPC"
      .Cells(4, 2).Value = x1.EPCLL
      .Cells(4, 3).Value = x1.EPCLM
      .Cells(4, 4).Value = x1.EPCCM

      'Dim ec As Drawing.Chart.ExcelChart = .Drawings("Chart2")
      ' ec.Series.Add()


    End With
    '    ----MRNV
    'MRN -1
    ' Dim xlWS1 As ExcelWorksheet = xlPk.Workbook.Worksheets("MRN")
    Dim x7 As MRNVData = MRNVData.GetMRNVData(FMon)
    Dim d7 As MRNVData.DateObj = MRNVData.GetDateObj(FMon)
    With xlWS1

      .Cells(1, 6).Value = "Vehicle Reached at Site as per MRN"
      .Cells(1, 7).Value = MonthName(d7.ll_FromDate.Month)
      .Cells(1, 8).Value = MonthName(d7.l_FromDate.Month)
      .Cells(1, 9).Value = MonthName(d7.c_FromDate.Month)

      .Cells(2, 6).Value = "BOILER"
      .Cells(2, 7).Value = x7.BoilerLL
      .Cells(2, 8).Value = x7.BoilerLM
      .Cells(2, 9).Value = x7.BoilerCM

      .Cells(3, 6).Value = "SMD"
      .Cells(3, 7).Value = x7.SMDLL
      .Cells(3, 8).Value = x7.SMDLM
      .Cells(3, 9).Value = x7.SMDCM

      .Cells(4, 6).Value = "EPC"
      .Cells(4, 7).Value = x7.EPCLL
      .Cells(4, 8).Value = x7.EPCLM
      .Cells(4, 9).Value = x7.EPCCM

      'Dim ec As Drawing.Chart.ExcelChart = .Drawings("Chart2")
      ' ec.Series.Add()


    End With
    '----MRNV









    xlPk.Workbook.Calculate


    'NOTES DATA FOR PURCHASE REQUISITION -2

    Dim xlWS2 As ExcelWorksheet = xlPk.Workbook.Worksheets("NOTES")
    Dim x2 As NOTESData = NOTESData.GetNOTESData(FMon)
    Dim d2 As NOTESData.DateObj = NOTESData.GetDateObj(FMon)
    With xlWS2


      .Cells(2, 1).Value = "DIVISION"
      .Cells(2, 2).Value = MonthName(d2.ll_FromDate.Month)
      .Cells(2, 3).Value = MonthName(d2.l_FromDate.Month)
      .Cells(2, 4).Value = MonthName(d2.c_FromDate.Month)

      .Cells(3, 1).Value = "BOILER"
      .Cells(3, 2).Value = x2.BoilerLLNPR
      .Cells(3, 3).Value = x2.BoilerLMNPR
      .Cells(3, 4).Value = x2.BoilerCMNPR

      .Cells(4, 1).Value = "SMD"
      .Cells(4, 2).Value = x2.SMDLLNPR
      .Cells(4, 3).Value = x2.SMDLMNPR
      .Cells(4, 4).Value = x2.SMDCMNPR

      .Cells(5, 1).Value = "EPC"
      .Cells(5, 2).Value = x2.EPCLLNPR
      .Cells(5, 3).Value = x2.EPCLMNPR
      .Cells(5, 4).Value = x2.EPCCMNPR

      .Cells(10, 1).Value = "DIVISION"
      .Cells(10, 2).Value = MonthName(d2.ll_FromDate.Month)
      .Cells(10, 3).Value = MonthName(d2.l_FromDate.Month)
      .Cells(10, 4).Value = MonthName(d2.c_FromDate.Month)

      .Cells(11, 1).Value = "BOILER"
      .Cells(11, 2).Value = x2.BoilerLLNPO
      .Cells(11, 3).Value = x2.BoilerLMNPO
      .Cells(11, 4).Value = x2.BoilerCMNPO

      .Cells(12, 1).Value = "SMD"
      .Cells(12, 2).Value = x2.SMDLLNPO
      .Cells(12, 3).Value = x2.SMDLMNPO
      .Cells(12, 4).Value = x2.SMDCMNPO

      .Cells(13, 1).Value = "EPC"
      .Cells(13, 2).Value = x2.EPCLLNPO
      .Cells(13, 3).Value = x2.EPCLMNPO
      .Cells(13, 4).Value = x2.EPCCMNPO

      .Cells(18, 1).Value = "DIVISION"
      .Cells(18, 2).Value = MonthName(d2.ll_FromDate.Month)
      .Cells(18, 3).Value = MonthName(d2.l_FromDate.Month)
      .Cells(18, 4).Value = MonthName(d2.c_FromDate.Month)

      .Cells(19, 1).Value = "BOILER"
      .Cells(19, 2).Value = x2.BoilerLLNAW
      .Cells(19, 3).Value = x2.BoilerLMNAW
      .Cells(19, 4).Value = x2.BoilerCMNAW

      .Cells(20, 1).Value = "SMD"
      .Cells(20, 2).Value = x2.SMDLLNAW
      .Cells(20, 3).Value = x2.SMDLMNAW
      .Cells(20, 4).Value = x2.SMDCMNAW

      .Cells(21, 1).Value = "EPC"
      .Cells(21, 2).Value = x2.EPCLLNAW
      .Cells(21, 3).Value = x2.EPCLMNAW
      .Cells(21, 4).Value = x2.EPCCMNAW
    End With

    ' MOBILE APP DATA -3

    Dim xlWS3 As ExcelWorksheet = xlPk.Workbook.Worksheets("MOBILE APP")
    Dim x3 As MobileAppData = MobileAppData.GetMobileAppData()
    With xlWS3

      .Cells(1, 1).Value = "DIVISION"
      .Cells(1, 2).Value = "TOTAL NUMBER OF PROJECTS"
      .Cells(1, 3).Value = "TOTAL ACTIVITIES"
      .Cells(1, 4).Value = "UPDATED ACTIVITIES"

      .Cells(2, 2).Value = x3.BOILERCTP
      .Cells(3, 2).Value = x3.SMDCTP
      .Cells(4, 2).Value = x3.EPCCTP
      .Cells(5, 2).Value = x3.BOILERSTP
      .Cells(6, 2).Value = x3.BOILEROTP

      .Cells(2, 3).Value = x3.BOILERCTA
      .Cells(3, 3).Value = x3.SMDCTA
      .Cells(4, 3).Value = x3.EPCCTA
      .Cells(5, 3).Value = x3.BOILERSTA
      .Cells(6, 3).Value = x3.BOILEROTA

      .Cells(2, 4).Value = x3.BOILERCUA
      .Cells(3, 4).Value = x3.SMDCUA
      .Cells(4, 4).Value = x3.EPCCUA
      .Cells(5, 4).Value = x3.BOILERSUA
      .Cells(6, 4).Value = x3.BOILEROUA


    End With

    'NOTES DATA FOR PACKING LIST -4

    Dim xlWS4 As ExcelWorksheet = xlPk.Workbook.Worksheets("PACKING LIST")
    Dim x4 As PKLData = PKLData.GetPKLData(FMon)
    Dim d4 As PKLData.DateObj = PKLData.GetDateObj(FMon)
    With xlWS4


      .Cells(2, 1).Value = "DIVISION"
      .Cells(2, 2).Value = MonthName(d4.ll_FromDate.Month)
      .Cells(2, 3).Value = MonthName(d4.l_FromDate.Month)
      .Cells(2, 4).Value = MonthName(d4.c_FromDate.Month)

      .Cells(3, 1).Value = "BOILER"
      .Cells(3, 2).Value = x4.BoilerLLPKLV
      .Cells(3, 3).Value = x4.BoilerLMPKLV
      .Cells(3, 4).Value = x4.BoilerCMPKLV

      .Cells(4, 1).Value = "SMD"
      .Cells(4, 2).Value = x4.SMDLLPKLV
      .Cells(4, 3).Value = x4.SMDLMPKLV
      .Cells(4, 4).Value = x4.SMDCMPKLV

      .Cells(5, 1).Value = "EPC"
      .Cells(5, 2).Value = x4.EPCLLPKLV
      .Cells(5, 3).Value = x4.EPCLMPKLV
      .Cells(5, 4).Value = x4.EPCCMPKLV

      .Cells(6, 1).Value = "ESP"
      .Cells(6, 2).Value = x4.ESPCMPKLV
      .Cells(6, 3).Value = x4.ESPLMPKLV
      .Cells(6, 4).Value = x4.ESPCMPKLV

      .Cells(10, 1).Value = "DIVISION"
      .Cells(10, 2).Value = MonthName(d4.ll_FromDate.Month)
      .Cells(10, 3).Value = MonthName(d4.l_FromDate.Month)
      .Cells(10, 4).Value = MonthName(d4.c_FromDate.Month)

      .Cells(11, 1).Value = "BOILER"
      .Cells(11, 2).Value = x4.BoilerLLPKLE
      .Cells(11, 3).Value = x4.BoilerLMPKLE
      .Cells(11, 4).Value = x4.BoilerCMPKLE

      .Cells(12, 1).Value = "SMD"
      .Cells(12, 2).Value = x4.SMDLLPKLE
      .Cells(12, 3).Value = x4.SMDLMPKLE
      .Cells(12, 4).Value = x4.SMDCMPKLE

      .Cells(13, 1).Value = "EPC"
      .Cells(13, 2).Value = x4.EPCLLPKLE
      .Cells(13, 3).Value = x4.EPCLMPKLE
      .Cells(13, 4).Value = x4.EPCCMPKLE

      .Cells(14, 1).Value = "ESP"
      .Cells(14, 2).Value = x4.ESPLLPKLE
      .Cells(14, 3).Value = x4.ESPLMPKLE
      .Cells(14, 4).Value = x4.ESPCMPKLE

    End With

    ' PREORDERWFDATA -5
    Dim xlWS5 As ExcelWorksheet = xlPk.Workbook.Worksheets("PRE ORDER WORKFLOW")
    Dim x5 As POWData = POWData.GetPOWData(FMon)
    Dim d5 As POWData.DateObj = POWData.GetDateObj(FMon)
    With xlWS5
      .Cells(2, 1).Value = "DIVISION"
      .Cells(2, 2).Value = MonthName(d5.ll_FromDate.Month)
      .Cells(2, 3).Value = MonthName(d5.l_FromDate.Month)
      .Cells(2, 4).Value = MonthName(d5.c_FromDate.Month)
      .Cells(3, 1).Value = "BOILER"
      .Cells(3, 2).Value = x5.BoilerLLPOW
      .Cells(3, 3).Value = x5.BoilerLMPOW
      .Cells(3, 4).Value = x5.BoilerCMPOW
      .Cells(4, 1).Value = "SMD"
      .Cells(4, 2).Value = x5.SMDLLPOW
      .Cells(4, 3).Value = x5.SMDLMPOW
      .Cells(4, 4).Value = x5.SMDCMPOW
      .Cells(5, 1).Value = "EPC"
      .Cells(5, 2).Value = x5.EPCLLPOW
      .Cells(5, 3).Value = x5.EPCLMPOW
      .Cells(5, 4).Value = x5.EPCCMPOW

      Dim ec As Drawing.Chart.ExcelChart = .Drawings("Chart2")
      ' ec.Series.Add()


    End With

    ' IDMS DATA -6
    Dim xlWS6 As ExcelWorksheet = xlPk.Workbook.Worksheets("IDMS")
    Dim x6 As IDMSData = IDMSData.GetIDMSData(FMon)
    Dim d6 As IDMSData.DateObj = IDMSData.GetDateObj(FMon)
    With xlWS6
      .Cells(2, 1).Value = "DIVISION"
      .Cells(2, 2).Value = MonthName(d6.ll_FromDate.Month)
      .Cells(2, 3).Value = MonthName(d6.l_FromDate.Month)
      .Cells(2, 4).Value = MonthName(d6.c_FromDate.Month)
      .Cells(3, 1).Value = "BOILER"
      .Cells(3, 2).Value = x6.BoilerLLIP
      .Cells(3, 3).Value = x6.BoilerLMIP
      .Cells(3, 4).Value = x6.BoilerCMIP
      .Cells(4, 1).Value = "SMD"
      .Cells(4, 2).Value = x6.SMDLLIP
      .Cells(4, 3).Value = x6.SMDLMIP
      .Cells(4, 4).Value = x6.SMDCMIP
      .Cells(5, 1).Value = "EPC"
      .Cells(5, 2).Value = x6.EPCLLIP
      .Cells(5, 3).Value = x6.EPCLMIP
      .Cells(5, 4).Value = x6.EPCCMIP


      .Cells(10, 1).Value = "DIVISION"
      .Cells(10, 2).Value = MonthName(d6.ll_FromDate.Month)
      .Cells(10, 3).Value = MonthName(d6.l_FromDate.Month)
      .Cells(10, 4).Value = MonthName(d6.c_FromDate.Month)
      .Cells(11, 1).Value = "BOILER"
      .Cells(11, 2).Value = x6.BoilerLLIO
      .Cells(11, 3).Value = x6.BoilerLMIO
      .Cells(11, 4).Value = x6.BoilerCMIO
      .Cells(12, 1).Value = "SMD"
      .Cells(12, 2).Value = x6.SMDLLIO
      .Cells(12, 3).Value = x6.SMDLMIO
      .Cells(12, 4).Value = x6.SMDCMIO
      .Cells(13, 1).Value = "EPC"
      .Cells(13, 2).Value = x6.EPCLLIO
      .Cells(13, 3).Value = x6.EPCLMIO
      .Cells(13, 4).Value = x6.EPCCMIO


      .Cells(18, 1).Value = "DIVISION"
      .Cells(18, 2).Value = MonthName(d6.ll_FromDate.Month)
      .Cells(18, 3).Value = MonthName(d6.l_FromDate.Month)
      .Cells(18, 4).Value = MonthName(d6.c_FromDate.Month)
      .Cells(19, 1).Value = "BOILER"
      .Cells(19, 2).Value = x6.BoilerLLIS
      .Cells(19, 3).Value = x6.BoilerLMIS
      .Cells(19, 4).Value = x6.BoilerCMIS
      .Cells(20, 1).Value = "SMD"
      .Cells(20, 2).Value = x6.SMDLLIS
      .Cells(20, 3).Value = x6.SMDLMIS
      .Cells(20, 4).Value = x6.SMDCMIS
      .Cells(21, 1).Value = "EPC"
      .Cells(21, 2).Value = x6.EPCLLIS
      .Cells(21, 3).Value = x6.EPCLMIS
      .Cells(21, 4).Value = x6.EPCCMIS


      '  Dim ec As Drawing.Chart.ExcelChart = .Drawings("Chart2")
      ' ec.Series.Add()


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
Public Class MRNData
  Public Structure DateObj
    Dim c_FromDate As DateTime
    Dim c_ToDate As DateTime
    Dim l_FromDate As DateTime
    Dim l_ToDate As DateTime
    Dim ll_FromDate As DateTime
    Dim ll_ToDate As DateTime
  End Structure
  Public Property BoilerCM As Integer = 0
  Public Property BoilerLM As Integer = 0
  Public Property BoilerLL As Integer = 0
  Public Property SMDCM As Integer = 0
  Public Property SMDLM As Integer = 0
  Public Property SMDLL As Integer = 0
  Public Property EPCCM As Integer = 0
  Public Property EPCLM As Integer = 0
  Public Property EPCLL As Integer = 0

  'Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
  '  Dim x As New DateObj
  '  Dim cYr As Integer = Now.Year
  '  Select Case FMon
  '    Case "01"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.l_FromDate = "01/12/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      x.ll_FromDate = "01/11/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case "02"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      x.l_FromDate = "01/01/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.ll_FromDate = "01/12/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case Else
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.l_FromDate = "01/" & FMon & "/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.ll_FromDate = "01/" & FMon & "/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '  End Select

  '  Return x
  'End Function
  Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
    Dim x As New DateObj
    Dim cYr As Integer = Now.Year
    Select Case FMon
      Case "01"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.l_FromDate = "01/12/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        x.ll_FromDate = "01/11/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case "02"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        x.l_FromDate = "01/01/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.ll_FromDate = "01/12/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case Else
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.l_FromDate = "01/" & FMon & "/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.ll_FromDate = "01/" & FMon & "/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
    End Select

    Return x
  End Function

  Public Shared Function GetMRNData(ByVal FMon As String) As MRNData
    Dim x As DateObj = MRNData.GetDateObj(FMon)
    Dim tmp As MRNData = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spERP_HK_GetMrnData"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cf", SqlDbType.NVarChar, 10, x.c_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ct", SqlDbType.NVarChar, 10, x.c_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lf", SqlDbType.NVarChar, 10, x.l_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lt", SqlDbType.NVarChar, 10, x.l_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tf", SqlDbType.NVarChar, 10, x.ll_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tt", SqlDbType.NVarChar, 10, x.ll_ToDate.ToString("dd/MM/yyyy"))
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New MRNData
          With tmp
            .BoilerCM = Reader("BoilerCM")
            .BoilerLM = Reader("BoilerLM")
            .BoilerLL = Reader("BoilerLL")
            .SMDCM = Reader("SMDCM")
            .SMDLM = Reader("SMDLM")
            .SMDLL = Reader("SMDLL")
            .EPCCM = Reader("EPCCM")
            .EPCLM = Reader("EPCLM")
            .EPCLL = Reader("EPCLL")
          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function



End Class
Public Class MobileAppData
  Public Property BOILERCTP As Integer = 0
  Public Property SMDCTP As Integer = 0
  Public Property EPCCTP As Integer = 0
  Public Property BOILERSTP As Integer = 0
  Public Property BOILEROTP As Integer = 0
  Public Property BOILERCTA As Integer = 0
  Public Property SMDCTA As Integer = 0
  Public Property EPCCTA As Integer = 0
  Public Property BOILERSTA As Integer = 0
  Public Property BOILEROTA As Integer = 0
  Public Property BOILERCUA As Integer = 0
  Public Property SMDCUA As Integer = 0
  Public Property EPCCUA As Integer = 0
  Public Property BOILERSUA As Integer = 0
  Public Property BOILEROUA As Integer = 0




  Public Shared Function GetMobileAppData() As MobileAppData

    Dim tmp As MobileAppData = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = "select * from HK_GetMobileAppData"


        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New MobileAppData
          With tmp
            .BOILERCTP = Reader("BOILERCTP")
            .SMDCTP = Reader("SMDCTP")
            .EPCCTP = Reader("EPCCTP")
            .BOILERSTP = Reader("BOILERSTP")
            .BOILEROTP = Reader("BOILEROTP")
            .BOILERCTA = Reader("BOILERCTA")
            .SMDCTA = Reader("SMDCTA")
            .EPCCTA = Reader("EPCCTA")
            .BOILERSTA = Reader("BOILERSTA")
            .BOILEROTA = Reader("BOILEROTA")
            .BOILERCUA = Reader("BOILERCUA")
            .SMDCUA = Reader("SMDCUA")
            .EPCCUA = Reader("EPCCUA")
            .BOILERSUA = Reader("BOILERSUA")
            .BOILEROUA = Reader("BOILEROUA")


          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function
End Class

Public Class NOTESData
  Public Structure DateObj
    Dim c_FromDate As DateTime
    Dim c_ToDate As DateTime
    Dim l_FromDate As DateTime
    Dim l_ToDate As DateTime
    Dim ll_FromDate As DateTime
    Dim ll_ToDate As DateTime
  End Structure


  Public Property BoilerLLNPR As Integer = 0
  Public Property BoilerLMNPR As Integer = 0
  Public Property BoilerCMNPR As Integer = 0
  Public Property SMDLLNPR As Integer = 0
  Public Property SMDLMNPR As Integer = 0
  Public Property SMDCMNPR As Integer = 0
  Public Property EPCLLNPR As Integer = 0
  Public Property EPCLMNPR As Integer = 0
  Public Property EPCCMNPR As Integer = 0
  Public Property BoilerLLNPO As Integer = 0
  Public Property BoilerLMNPO As Integer = 0
  Public Property BoilerCMNPO As Integer = 0
  Public Property SMDLLNPO As Integer = 0
  Public Property SMDLMNPO As Integer = 0
  Public Property SMDCMNPO As Integer = 0
  Public Property EPCLLNPO As Integer = 0
  Public Property EPCLMNPO As Integer = 0
  Public Property EPCCMNPO As Integer = 0
  Public Property BoilerLLNAW As Integer = 0
  Public Property BoilerLMNAW As Integer = 0
  Public Property BoilerCMNAW As Integer = 0
  Public Property SMDLLNAW As Integer = 0
  Public Property SMDLMNAW As Integer = 0
  Public Property SMDCMNAW As Integer = 0
  Public Property EPCLLNAW As Integer = 0
  Public Property EPCLMNAW As Integer = 0
  Public Property EPCCMNAW As Integer = 0



  'Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
  '  Dim x As New DateObj
  '  Dim cYr As Integer = Now.Year
  '  Select Case FMon
  '    Case "01"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.l_FromDate = "01/12/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      x.ll_FromDate = "01/11/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case "02"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      x.l_FromDate = "01/01/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.ll_FromDate = "01/12/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case Else
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.l_FromDate = "01/" & FMon & "/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.ll_FromDate = "01/" & FMon & "/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '  End Select

  '  Return x
  'End Function

  Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
    Dim x As New DateObj
    Dim cYr As Integer = Now.Year
    Select Case FMon
      Case "01"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.l_FromDate = "01/12/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        x.ll_FromDate = "01/11/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case "02"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        x.l_FromDate = "01/01/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.ll_FromDate = "01/12/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case Else
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.l_FromDate = "01/" & FMon & "/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.ll_FromDate = "01/" & FMon & "/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
    End Select

    Return x
  End Function

  Public Shared Function GetNOTESData(ByVal FMon As String) As NOTESData
    Dim x As DateObj = NOTESData.GetDateObj(FMon)
    Dim tmp As NOTESData = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spERP_HK_GetNotesData"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cf", SqlDbType.NVarChar, 10, x.c_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ct", SqlDbType.NVarChar, 10, x.c_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lf", SqlDbType.NVarChar, 10, x.l_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lt", SqlDbType.NVarChar, 10, x.l_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tf", SqlDbType.NVarChar, 10, x.ll_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tt", SqlDbType.NVarChar, 10, x.ll_ToDate.ToString("dd/MM/yyyy"))
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New NOTESData
          With tmp
            .BoilerCMNPR = Reader("BoilerCMNPR")
            .BoilerLMNPR = Reader("BoilerLMNPR")
            .BoilerLLNPR = Reader("BoilerLLNPR")
            .SMDCMNPR = Reader("SMDCMNPR")
            .SMDLMNPR = Reader("SMDLMNPR")
            .SMDLLNPR = Reader("SMDLLNPR")
            .EPCCMNPR = Reader("EPCCMNPR")
            .EPCLMNPR = Reader("EPCLMNPR")
            .EPCLLNPR = Reader("EPCLLNPR")
            .BoilerCMNPO = Reader("BoilerCMNPO")
            .BoilerLMNPO = Reader("BoilerLMNPO")
            .BoilerLLNPO = Reader("BoilerLLNPO")
            .SMDCMNPO = Reader("SMDCMNPO")
            .SMDLMNPO = Reader("SMDLMNPO")
            .SMDLLNPO = Reader("SMDLLNPO")
            .EPCCMNPO = Reader("EPCCMNPO")
            .EPCLMNPO = Reader("EPCLMNPO")
            .EPCLLNPO = Reader("EPCLLNPO")
            .BoilerCMNAW = Reader("BoilerCMNAW")
            .BoilerLMNAW = Reader("BoilerLMNAW")
            .BoilerLLNAW = Reader("BoilerLLNAW")
            .SMDCMNAW = Reader("SMDCMNAW")
            .SMDLMNAW = Reader("SMDLMNAW")
            .SMDLLNAW = Reader("SMDLLNAW")
            .EPCCMNAW = Reader("EPCCMNAW")
            .EPCLMNAW = Reader("EPCLMNAW")
            .EPCLLNAW = Reader("EPCLLNAW")
          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function

End Class

Public Class PKLData
  Public Structure DateObj
    Dim c_FromDate As DateTime
    Dim c_ToDate As DateTime
    Dim l_FromDate As DateTime
    Dim l_ToDate As DateTime
    Dim ll_FromDate As DateTime
    Dim ll_ToDate As DateTime
  End Structure


  Public Property BoilerLLPKLV As Integer = 0
  Public Property BoilerLMPKLV As Integer = 0
  Public Property BoilerCMPKLV As Integer = 0
  Public Property SMDLLPKLV As Integer = 0
  Public Property SMDLMPKLV As Integer = 0
  Public Property SMDCMPKLV As Integer = 0
  Public Property EPCLLPKLV As Integer = 0
  Public Property EPCLMPKLV As Integer = 0
  Public Property EPCCMPKLV As Integer = 0
  Public Property ESPLLPKLV As Integer = 0
  Public Property ESPLMPKLV As Integer = 0
  Public Property ESPCMPKLV As Integer = 0
  Public Property BoilerLLPKLE As Integer = 0
  Public Property BoilerLMPKLE As Integer = 0
  Public Property BoilerCMPKLE As Integer = 0
  Public Property SMDLLPKLE As Integer = 0
  Public Property SMDLMPKLE As Integer = 0
  Public Property SMDCMPKLE As Integer = 0
  Public Property EPCLLPKLE As Integer = 0
  Public Property EPCLMPKLE As Integer = 0
  Public Property EPCCMPKLE As Integer = 0
  Public Property ESPLLPKLE As Integer = 0
  Public Property ESPLMPKLE As Integer = 0
  Public Property ESPCMPKLE As Integer = 0




  'Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
  '  Dim x As New DateObj
  '  Dim cYr As Integer = Now.Year
  '  Select Case FMon
  '    Case "01"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.l_FromDate = "01/12/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      x.ll_FromDate = "01/11/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case "02"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      x.l_FromDate = "01/01/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.ll_FromDate = "01/12/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case Else
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.l_FromDate = "01/" & FMon & "/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.ll_FromDate = "01/" & FMon & "/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '  End Select

  '  Return x
  'End Function
  Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
    Dim x As New DateObj
    Dim cYr As Integer = Now.Year
    Select Case FMon
      Case "01"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.l_FromDate = "01/12/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        x.ll_FromDate = "01/11/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case "02"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        x.l_FromDate = "01/01/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.ll_FromDate = "01/12/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case Else
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.l_FromDate = "01/" & FMon & "/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.ll_FromDate = "01/" & FMon & "/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
    End Select

    Return x
  End Function

  Public Shared Function GetPKLData(ByVal FMon As String) As PKLData
    Dim x As DateObj = PKLData.GetDateObj(FMon)
    Dim tmp As PKLData = Nothing
    'GetBaaNConnectionString
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spERP_HK_GetPKLData"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cf", SqlDbType.NVarChar, 10, x.c_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ct", SqlDbType.NVarChar, 10, x.c_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lf", SqlDbType.NVarChar, 10, x.l_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lt", SqlDbType.NVarChar, 10, x.l_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tf", SqlDbType.NVarChar, 10, x.ll_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tt", SqlDbType.NVarChar, 10, x.ll_ToDate.ToString("dd/MM/yyyy"))
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New PKLData
          With tmp
            .BoilerCMPKLV = Reader("BoilerCMPKLV")
            .BoilerLMPKLV = Reader("BoilerLMPKLV")
            .BoilerLLPKLV = Reader("BoilerLLPKLV")
            .SMDCMPKLV = Reader("SMDCMPKLV")
            .SMDLMPKLV = Reader("SMDLMPKLV")
            .SMDLLPKLV = Reader("SMDLLPKLV")
            .EPCCMPKLV = Reader("EPCCMPKLV")
            .EPCLMPKLV = Reader("EPCLMPKLV")
            .EPCLLPKLV = Reader("EPCLLPKLV")
            .ESPCMPKLV = Reader("ESPCMPKLV")
            .ESPLMPKLV = Reader("ESPLMPKLV")
            .ESPLLPKLV = Reader("ESPLLPKLV")

            .BoilerCMPKLE = Reader("BoilerCMPKLE")
            .BoilerLMPKLE = Reader("BoilerLMPKLE")
            .BoilerLLPKLE = Reader("BoilerLLPKLE")
            .SMDCMPKLE = Reader("SMDCMPKLE")
            .SMDLMPKLE = Reader("SMDLMPKLE")
            .SMDLLPKLE = Reader("SMDLLPKLE")
            .EPCCMPKLE = Reader("EPCCMPKLE")
            .EPCLMPKLE = Reader("EPCLMPKLE")
            .EPCLLPKLE = Reader("EPCLLPKLE")
            .ESPCMPKLE = Reader("ESPCMPKLE")
            .ESPLMPKLE = Reader("ESPLMPKLE")
            .ESPLLPKLE = Reader("ESPLLPKLE")

          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function

End Class

Public Class POWData
  Public Structure DateObj
    Dim c_FromDate As DateTime
    Dim c_ToDate As DateTime
    Dim l_FromDate As DateTime
    Dim l_ToDate As DateTime
    Dim ll_FromDate As DateTime
    Dim ll_ToDate As DateTime
  End Structure


  Public Property BoilerLLPOW As Integer = 0
  Public Property BoilerLMPOW As Integer = 0
  Public Property BoilerCMPOW As Integer = 0
  Public Property SMDLLPOW As Integer = 0
  Public Property SMDLMPOW As Integer = 0
  Public Property SMDCMPOW As Integer = 0
  Public Property EPCLLPOW As Integer = 0
  Public Property EPCLMPOW As Integer = 0
  Public Property EPCCMPOW As Integer = 0



  'Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
  '  Dim x As New DateObj
  '  Dim cYr As Integer = Now.Year
  '  Select Case FMon
  '    Case "01"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.l_FromDate = "01/12/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      x.ll_FromDate = "01/11/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case "02"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      x.l_FromDate = "01/01/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.ll_FromDate = "01/12/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case Else
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.l_FromDate = "01/" & FMon & "/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.ll_FromDate = "01/" & FMon & "/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '  End Select

  '  Return x
  'End Function

  Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
    Dim x As New DateObj
    Dim cYr As Integer = Now.Year
    Select Case FMon
      Case "01"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.l_FromDate = "01/12/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        x.ll_FromDate = "01/11/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case "02"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        x.l_FromDate = "01/01/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.ll_FromDate = "01/12/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case Else
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.l_FromDate = "01/" & FMon & "/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.ll_FromDate = "01/" & FMon & "/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
    End Select

    Return x
  End Function

  Public Shared Function GetPOWData(ByVal FMon As String) As POWData
    Dim x As DateObj = POWData.GetDateObj(FMon)
    Dim tmp As POWData = Nothing
    'GetBaaNConnectionString
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spERP_HK_GetPOWData"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cf", SqlDbType.NVarChar, 10, x.c_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ct", SqlDbType.NVarChar, 10, x.c_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lf", SqlDbType.NVarChar, 10, x.l_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lt", SqlDbType.NVarChar, 10, x.l_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tf", SqlDbType.NVarChar, 10, x.ll_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tt", SqlDbType.NVarChar, 10, x.ll_ToDate.ToString("dd/MM/yyyy"))
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New POWData
          With tmp
            .BoilerCMPOW = Reader("BoilerCMPOW")
            .BoilerLMPOW = Reader("BoilerLMPOW")
            .BoilerLLPOW = Reader("BoilerLLPOW")
            .SMDCMPOW = Reader("SMDCMPOW")
            .SMDLMPOW = Reader("SMDLMPOW")
            .SMDLLPOW = Reader("SMDLLPOW")
            .EPCCMPOW = Reader("EPCCMPOW")
            .EPCLMPOW = Reader("EPCLMPOW")
            .EPCLLPOW = Reader("EPCLLPOW")


          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function

End Class

Public Class IDMSData
  Public Structure DateObj
    Dim c_FromDate As DateTime
    Dim c_ToDate As DateTime
    Dim l_FromDate As DateTime
    Dim l_ToDate As DateTime
    Dim ll_FromDate As DateTime
    Dim ll_ToDate As DateTime
  End Structure


  Public Property BoilerLLIP As Integer = 0
  Public Property BoilerLMIP As Integer = 0
  Public Property BoilerCMIP As Integer = 0
  Public Property SMDLLIP As Integer = 0
  Public Property SMDLMIP As Integer = 0
  Public Property SMDCMIP As Integer = 0
  Public Property EPCLLIP As Integer = 0
  Public Property EPCLMIP As Integer = 0
  Public Property EPCCMIP As Integer = 0


  Public Property BoilerLLIO As Integer = 0
  Public Property BoilerLMIO As Integer = 0
  Public Property BoilerCMIO As Integer = 0
  Public Property SMDLLIO As Integer = 0
  Public Property SMDLMIO As Integer = 0
  Public Property SMDCMIO As Integer = 0
  Public Property EPCLLIO As Integer = 0
  Public Property EPCLMIO As Integer = 0
  Public Property EPCCMIO As Integer = 0


  Public Property BoilerLLIS As Integer = 0
  Public Property BoilerLMIS As Integer = 0
  Public Property BoilerCMIS As Integer = 0
  Public Property SMDLLIS As Integer = 0
  Public Property SMDLMIS As Integer = 0
  Public Property SMDCMIS As Integer = 0
  Public Property EPCLLIS As Integer = 0
  Public Property EPCLMIS As Integer = 0
  Public Property EPCCMIS As Integer = 0



  'Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
  '  Dim x As New DateObj
  '  Dim cYr As Integer = Now.Year
  '  Select Case FMon
  '    Case "01"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
  '      cYr = cYr - 1
  '      x.l_FromDate = "01/12/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
  '      x.ll_FromDate = "01/11/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
  '    Case "02"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
  '      x.l_FromDate = "01/01/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
  '      cYr = cYr - 1
  '      x.ll_FromDate = "01/12/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
  '    Case Else
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.l_FromDate = "01/" & FMon & "/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.ll_FromDate = "01/" & FMon & "/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
  '  End Select

  '  Return x
  'End Function


  Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
    Dim x As New DateObj
    Dim cYr As Integer = Now.Year
    Select Case FMon
      Case "01"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.l_FromDate = "01/12/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        x.ll_FromDate = "01/11/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case "02"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        x.l_FromDate = "01/01/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.ll_FromDate = "01/12/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case Else
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.l_FromDate = "01/" & FMon & "/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.ll_FromDate = "01/" & FMon & "/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
    End Select

    Return x
  End Function

  Public Shared Function GetIDMSData(ByVal FMon As String) As IDMSData
    Dim x As DateObj = IDMSData.GetDateObj(FMon)
    Dim tmp As IDMSData = Nothing
    'GetBaaNConnectionString
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spERP_HK_GetIDMSData"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cf", SqlDbType.NVarChar, 10, x.c_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ct", SqlDbType.NVarChar, 10, x.c_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lf", SqlDbType.NVarChar, 10, x.l_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lt", SqlDbType.NVarChar, 10, x.l_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tf", SqlDbType.NVarChar, 10, x.ll_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tt", SqlDbType.NVarChar, 10, x.ll_ToDate.ToString("dd/MM/yyyy"))
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New IDMSData
          With tmp
            .BoilerCMIP = Reader("BoilerCMIP")
            .BoilerLMIP = Reader("BoilerLMIP")
            .BoilerLLIP = Reader("BoilerLLIP")
            .SMDCMIP = Reader("SMDCMIP")
            .SMDLMIP = Reader("SMDLMIP")
            .SMDLLIP = Reader("SMDLLIP")
            .EPCCMIP = Reader("EPCCMIP")
            .EPCLMIP = Reader("EPCLMIP")
            .EPCLLIP = Reader("EPCLLIP")
            .BoilerCMIO = Reader("BoilerCMIO")
            .BoilerLMIO = Reader("BoilerLMIO")
            .BoilerLLIO = Reader("BoilerLLIO")
            .SMDCMIO = Reader("SMDCMIO")
            .SMDLMIO = Reader("SMDLMIO")
            .SMDLLIO = Reader("SMDLLIO")
            .EPCCMIO = Reader("EPCCMIO")
            .EPCLMIO = Reader("EPCLMIO")
            .EPCLLIO = Reader("EPCLLIO")
            .BoilerCMIS = Reader("BoilerCMIS")
            .BoilerLMIS = Reader("BoilerLMIS")
            .BoilerLLIS = Reader("BoilerLLIS")
            .SMDCMIS = Reader("SMDCMIS")
            .SMDLMIS = Reader("SMDLMIS")
            .SMDLLIS = Reader("SMDLLIS")
            .EPCCMIS = Reader("EPCCMIS")
            .EPCLMIS = Reader("EPCLMIS")
            .EPCLLIS = Reader("EPCLLIS")
          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function

End Class
Public Class MRNVData
  Public Structure DateObj
    Dim c_FromDate As DateTime
    Dim c_ToDate As DateTime
    Dim l_FromDate As DateTime
    Dim l_ToDate As DateTime
    Dim ll_FromDate As DateTime
    Dim ll_ToDate As DateTime
  End Structure
  Public Property BoilerCM As Integer = 0
  Public Property BoilerLM As Integer = 0
  Public Property BoilerLL As Integer = 0
  Public Property SMDCM As Integer = 0
  Public Property SMDLM As Integer = 0
  Public Property SMDLL As Integer = 0
  Public Property EPCCM As Integer = 0
  Public Property EPCLM As Integer = 0
  Public Property EPCLL As Integer = 0

  'Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
  '  Dim x As New DateObj
  '  Dim cYr As Integer = Now.Year
  '  Select Case FMon
  '    Case "01"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.l_FromDate = "01/12/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      x.ll_FromDate = "01/11/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case "02"
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      x.l_FromDate = "01/01/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      cYr = cYr - 1
  '      x.ll_FromDate = "01/12/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '    Case Else
  '      x.c_FromDate = "01/" & FMon & "/" & cYr
  '      x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.l_FromDate = "01/" & FMon & "/" & cYr
  '      x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
  '      FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
  '      x.ll_FromDate = "01/" & FMon & "/" & cYr
  '      x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
  '  End Select

  '  Return x
  'End Function
  Public Shared Function GetDateObj(ByVal FMon As String) As DateObj
    Dim x As New DateObj
    Dim cYr As Integer = Now.Year
    Select Case FMon
      Case "01"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.l_FromDate = "01/12/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        x.ll_FromDate = "01/11/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case "02"
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(0)
        x.l_FromDate = "01/01/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(0)
        cYr = cYr - 1
        x.ll_FromDate = "01/12/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(0)
      Case Else
        x.c_FromDate = "01/" & FMon & "/" & cYr
        x.c_ToDate = x.c_FromDate.AddMonths(1).AddDays(-1)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.l_FromDate = "01/" & FMon & "/" & cYr
        x.l_ToDate = x.l_FromDate.AddMonths(1).AddDays(-1)
        FMon = Convert.ToString(Convert.ToInt32(FMon) - 1).PadLeft(2, "0")
        x.ll_FromDate = "01/" & FMon & "/" & cYr
        x.ll_ToDate = x.ll_FromDate.AddMonths(1).AddDays(-1)
    End Select

    Return x
  End Function

  Public Shared Function GetMRNVData(ByVal FMon As String) As MRNVData
    Dim x As DateObj = MRNVData.GetDateObj(FMon)
    Dim tmp As MRNVData = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "spERP_HK_GetMrnVData"
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@cf", SqlDbType.NVarChar, 10, x.c_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ct", SqlDbType.NVarChar, 10, x.c_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lf", SqlDbType.NVarChar, 10, x.l_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@lt", SqlDbType.NVarChar, 10, x.l_ToDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tf", SqlDbType.NVarChar, 10, x.ll_FromDate.ToString("dd/MM/yyyy"))
        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@tt", SqlDbType.NVarChar, 10, x.ll_ToDate.ToString("dd/MM/yyyy"))
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If (Reader.Read()) Then
          tmp = New MRNVData
          With tmp
            .BoilerCM = Reader("BoilerCM")
            .BoilerLM = Reader("BoilerLM")
            .BoilerLL = Reader("BoilerLL")
            .SMDCM = Reader("SMDCM")
            .SMDLM = Reader("SMDLM")
            .SMDLL = Reader("SMDLL")
            .EPCCM = Reader("EPCCM")
            .EPCLM = Reader("EPCLM")
            .EPCLL = Reader("EPCLL")
          End With
        End If
        Reader.Close()
      End Using
    End Using
    Return tmp
  End Function



End Class
