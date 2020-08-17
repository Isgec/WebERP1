Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Xml
Public Class pdfWriter

  Public Shared Function generateXLPDF(ByVal PathFile As String, Optional OutputPath As String = "") As Boolean
    Dim mRet As Boolean = True
    If OutputPath = "" Then OutputPath = IO.Path.GetDirectoryName(PathFile)
    Dim xlAp As Microsoft.Office.Interop.Excel.ApplicationClass = Nothing
    Dim xlWbs As Workbooks = Nothing
    Dim xlWb As Workbook = Nothing
    Dim xlWs As Worksheet = Nothing
    Try
      xlAp = New Microsoft.Office.Interop.Excel.ApplicationClass
      Dim FileName As String = IO.Path.GetFileName(PathFile)
      xlWbs = xlAp.Workbooks
      Try
        xlWb = xlWbs.Open(PathFile)
      Catch ex As Exception
        mRet = False
      End Try
      If xlWb IsNot Nothing Then
        Dim tmp As String = OutputPath & "\" & FileName & ".PDF"
        If IO.File.Exists(tmp) Then
          IO.File.Delete(tmp)
        End If
        Try
          xlWs = xlWb.ActiveSheet
          xlWs.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, tmp, XlFixedFormatQuality.xlQualityStandard, True, True, OpenAfterPublish:=False)
          NAR(xlWs)
        Catch ex As Exception
          NAR(xlWs)
          mRet = False
        End Try
        xlWb.Close(False)
        NAR(xlWb)
      End If
      NAR(xlWbs)
      xlAp.Quit()
      NAR(xlAp)
    Catch ex As Exception
      mRet = False
    End Try
    Return mRet
  End Function
  Private Shared Sub NAR(ByVal o As Object)
    Try
      While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
      End While
    Catch
    Finally
      o = Nothing
    End Try
  End Sub

End Class
