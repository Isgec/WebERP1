Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpEvaluateByIT
    Inherits SIS.ERP.erpChaneRequest
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpEvaluateByITGetNewRecord() As SIS.ERP.erpEvaluateByIT
      Return New SIS.ERP.erpEvaluateByIT()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpEvaluateByITSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As List(Of SIS.ERP.erpEvaluateByIT)
      Dim Results As List(Of SIS.ERP.erpEvaluateByIT) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sperpEvaluateByITSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sperpEvaluateByITSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplID",SqlDbType.Int,10, IIf(ApplID = Nothing, 0,ApplID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy",SqlDbType.NVarChar,8, IIf(RequestedBy Is Nothing, String.Empty,RequestedBy))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestTypeID",SqlDbType.Int,10, IIf(RequestTypeID = Nothing, 0,RequestTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PriorityID",SqlDbType.Int,10, IIf(PriorityID = Nothing, 0,PriorityID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, 5)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ERP.erpEvaluateByIT)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpEvaluateByIT(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpEvaluateByITSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpEvaluateByITGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32) As SIS.ERP.erpEvaluateByIT
      Dim Results As SIS.ERP.erpEvaluateByIT = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,ApplID.ToString.Length, ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpEvaluateByIT(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpEvaluateByITGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal Filter_ApplID As Int32, ByVal Filter_RequestedBy As String, ByVal Filter_RequestTypeID As Int32, ByVal Filter_StatusID As Int32, ByVal Filter_PriorityID As Int32) As SIS.ERP.erpEvaluateByIT
      Dim Results As SIS.ERP.erpEvaluateByIT = SIS.ERP.erpEvaluateByIT.erpEvaluateByITGetByID(ApplID, RequestID)
      Return Results
    End Function
		Public Shared Function erpEvaluateByITUpdate(ByVal Record As SIS.ERP.erpEvaluateByIT) As SIS.ERP.erpChaneRequest
			Dim _Rec As SIS.ERP.erpChaneRequest = SIS.ERP.erpChaneRequest.erpChaneRequestGetByID(Record.ApplID, Record.RequestID)
			With _Rec
				.EvaluationByIT = Record.EvaluationByIT
				.Justification = Record.Justification
			End With
			Return SIS.ERP.erpChaneRequest.UpdateData(_Rec)
		End Function

		Public Sub New(ByVal Reader As SqlDataReader)
			MyBase.New(Reader)
		End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
