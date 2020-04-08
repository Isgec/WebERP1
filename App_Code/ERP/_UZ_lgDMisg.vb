Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
	Partial Public Class lgDMisg
		Public ReadOnly Property Stat() As String
			Get
				Dim mRet As String = ""
				Select Case _t_stat
					Case 1
						mRet = "Submitted"
					Case 2
						mRet = "Item Released"
					Case 3
						mRet = "Drawing Released"
					Case 4
						mRet = "Expired"
				End Select
				Return mRet
			End Get
		End Property
		Public ReadOnly Property WFStat() As String
			Get
				Dim mRet As String = ""
				Select Case _t_wfst
					Case 1
						mRet = "Under Design"
					Case 2
						mRet = "Submitted"
					Case 3
						mRet = "Under Review"
					Case 4
						mRet = "Under Approval"
					Case 5
						mRet = "Released"
					Case 6
						mRet = "Withdrawn"
					Case 7
						mRet = "Under Revision"
					Case 8
						mRet = "Superseded"
					Case 9
						mRet = "Under DCR"
				End Select
				Return mRet
			End Get
		End Property
		Public ReadOnly Property DocStatus() As String
			Get
				Dim mRet As String = ""
				Select Case _t_wfst
					Case 1, 2, 3, 4
						mRet = "NOT Released"
					Case 5
						mRet = "Released"
					Case 6
						mRet = "Withdrawn"
					Case 7, 8, 9
						mRet = "Under Revision"
				End Select
				Return mRet
			End Get
		End Property
		Public Shared Function lgDMisgSelectLatest(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
			Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splg_LG_DMisgSelectLatestSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splg_LG_DMisgSelectLatestFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 20, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.LG.lgDMisg)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.LG.lgDMisg(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
    Public Shared Function GetErectionDrawingListFromBaaN(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "splg_LG_GetErectionDrawing"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "splg_LG_GetErectionDrawing"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 20, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgDMisg)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgDMisg(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetErectionDrawingListFromBaaN_New(ByVal LastDays As Integer, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Dim Sql As String = ""
      Sql = Sql & "		SELECT"
      Sql = Sql & "     datediff(d,docM.t_drdt,getdate()) as Rele,"
      Sql = Sql & "     datediff(d,dcrH.t_appt,getdate()) as UD, "
      Sql = Sql & "     dcrH.t_dcrn ,"
      Sql = Sql & "			docM.t_docn ,"
      Sql = Sql & "			docM.t_revn ,"
      Sql = Sql & "			docM.t_dttl ,"
      Sql = Sql & "			docM.t_cspa ,"
      Sql = Sql & "			docM.t_cprj ,"
      Sql = Sql & "			docM.t_year ,"
      Sql = Sql & "			docM.t_stat ,"
      Sql = Sql & "			docM.t_wfst ,"
      Sql = Sql & "			docM.t_dsca ,"
      Sql = Sql & "			docM.t_sorc ,"
      Sql = Sql & "			(case when docM.t_wfst = 5 then docM.t_drdt else dcrH.t_appt end) as t_drdt ,"
      Sql = Sql & "			docM.t_name ,"
      Sql = Sql & "			docM.t_erec ,"
      Sql = Sql & "			docM.t_prod ,"
      Sql = Sql & "			docM.t_appr  "
      Sql = Sql & "		FROM tdmisg001200 as docM "
      Sql = Sql & "			left outer join tdmisg115200 as dcrL on (docM.t_docn = dcrL.t_docd and docM.t_revn = dcrL.t_revn)  "
      Sql = Sql & "			left outer join tdmisg114200 as dcrH on dcrL.t_dcrn = dcrH.t_dcrn "
      Sql = Sql & "		WHERE docM.t_revn = (SELECT MAX(tmp.t_revn) FROM tdmisg001200 as tmp WHERE tmp.t_docn= docM.t_docn) "
      Sql = Sql & "			AND docM.t_cprj = '" & t_cprj & "'"
      Sql = Sql & "			AND (docM.t_wfst = 5 OR docM.t_wfst = 7) "
      Sql = Sql & "			AND ((docM.t_wfst = 5 and datediff(d,docM.t_drdt,getdate()) <= " & LastDays & ") or (docM.t_wfst=7 and datediff(d,dcrH.t_appt,getdate()) <=" & LastDays & ")  )"

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.LG.lgDMisg)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgDMisg(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetErectionDrawingList_YNR_FromBaaN(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "splg_LG_GetErectionDrawing_YNR"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "splg_LG_GetErectionDrawing_YNR"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 20, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgDMisg)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgDMisg(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

    'Public Shared Function GetErectionDrawingList_YNR_FromBaaN(ByVal LastDays As Integer, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
    '  Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
    '  Dim Sql As String = ""
    '  Sql = Sql & "	SELECT     datediff(d,docM.t_drdt,getdate()) as Rele,datediff(d,dcrH.t_appt,getdate()) as UD,  dcrH.t_dcrn , "
    '  Sql = Sql & "	docM.t_docn , docM.t_revn, docM.t_dttl, docM.t_cspa, docM.t_cprj, docM.t_year, docM.t_stat, docM.t_wfst, docM.t_dsca, "
    '  Sql = Sql & "	docM.t_sorc ,(Case When docM.t_wfst = 5 Then docM.t_drdt Else dcrH.t_appt End) As t_drdt , "
    '  Sql = Sql & "	docM.t_name ,docM.t_erec ,docM.t_prod ,	docM.t_appr , "


    '  Sql = Sql & "	Case "

    '  Sql = Sql & "	when docM.t_cspa in ('50010000', '50010100', '50010300', '50010600') then 	'Drum' "

    '  Sql = Sql & "	when docM.t_cspa in ('50091200', '50091000', '50090800', '50090700', '50090601', '50090600', '50090500', '50090401', '50090400', '50090302', '50090301', '50090300', '50090202', '50090201', '50090200', '50090101', '50090100', '50090000') then 	'Piping' "

    '  Sql = Sql & "	When docM.t_cspa In ('50360400', '50360302', '50360301', '50360300', '50020000', '50020100', '50020200', '50020300', '50020400', '50020500', '50020600', '50360200', '50020900', '50021000', '50030000', '50030100', '50030200', '50030300', '50030400', '50030500', '50030600', '50030700', '50030800', '50030900', '50031000', '50031100', '50031200', '50031300', '50031400', '50031500', '50031600', '50032000', '50040000', '50040100', '50040200', '50040300', '50040400', '50040500', '50040600', '50040700', '50041000')  then 	'Tubes' "
    '  Sql = Sql & "	Else '-' "
    '  Sql = Sql & "	End As Shop, "

    '  Sql = Sql & "	TraD.t_tran as TranID , TraH.t_isdt as Tissue, "
    '  Sql = Sql & "	Case TraH.t_type"
    '  Sql = Sql & "	when 1 then 'Customer' "
    '  Sql = Sql & "	When 2 Then 'Internal' "
    '  Sql = Sql & "	when 3 then 'Site' "
    '  Sql = Sql & "	When 4 Then 'Vendor' "
    '  Sql = Sql & "	End As Ttype "
    '  Sql = Sql & "	From tdmisg001200 As docM "
    '  Sql = Sql & "	Left Join tdmisg115200 as dcrL on (docM.t_docn = dcrL.t_docd And docM.t_revn = dcrL.t_revn) "
    '  Sql = Sql & "	Left Join tdmisg132200 as TraD on (docM.t_docn = TraD.t_docn And docM.t_revn = TraD.t_revn) "
    '  Sql = Sql & "	Left Join tdmisg131200 as TraH on (TraD.t_tran = TraH.t_tran) "
    '  Sql = Sql & "	Left Join tdmisg114200 as dcrH on dcrL.t_dcrn = dcrH.t_dcrn  "
    '  Sql = Sql & "		WHERE docM.t_revn = (Select MAX(tmp.t_revn) FROM tdmisg001200 As tmp WHERE tmp.t_docn= docM.t_docn) "
    '  Sql = Sql & "			And docM.t_cprj = '" & t_cprj & "'"
    '  Sql = Sql & "			And docM.t_cspa in ('50010000', '50010100', '50010300', '50010600','50091200', '50091000', '50090800', '50090700', '50090601', '50090600', '50090500', '50090401', '50090400', '50090302', '50090301', '50090300', '50090202', '50090201', '50090200', '50090101', '50090100', '50090000','50360400', '50360302', '50360301', '50360300', '50020000', '50020100', '50020200', '50020300', '50020400', '50020500', '50020600', '50360200', '50020900', '50021000', '50030000', '50030100', '50030200', '50030300', '50030400', '50030500', '50030600', '50030700', '50030800', '50030900', '50031000', '50031100', '50031200', '50031300', '50031400', '50031500', '50031600', '50032000', '50040000', '50040100', '50040200', '50040300', '50040400', '50040500', '50040600', '50040700', '50041000') "

    '  Sql = Sql & "			AND (docM.t_wfst = 5 OR docM.t_wfst = 7) "

    '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
    '    Using Cmd As SqlCommand = Con.CreateCommand()
    '      Cmd.CommandType = CommandType.Text
    '      Cmd.CommandText = Sql
    '      Results = New List(Of SIS.LG.lgDMisg)
    '      Con.Open()
    '      Dim Reader As SqlDataReader = Cmd.ExecuteReader()
    '      While (Reader.Read())
    '        Results.Add(New SIS.LG.lgDMisg(Reader))
    '      End While
    '      Reader.Close()
    '    End Using
    '  End Using
    '  Return Results
    'End Function

    Public Shared Function GetErectionDrawingList_YNR_FromBaaN_New(ByVal LastDays As Integer, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Dim Sql As String = ""
      Sql = Sql & "	SELECT     datediff(d,docM.t_drdt,getdate()) as Rele,datediff(d,dcrH.t_appt,getdate()) as UD,  dcrH.t_dcrn , "
      Sql = Sql & "	docM.t_docn , docM.t_revn, docM.t_dttl, docM.t_cspa, docM.t_cprj, docM.t_year, docM.t_stat, docM.t_wfst, docM.t_dsca, "
      Sql = Sql & "	docM.t_sorc ,(Case When docM.t_wfst = 5 Then docM.t_drdt Else dcrH.t_appt End) As t_drdt , "
      Sql = Sql & "	docM.t_name ,docM.t_erec ,docM.t_prod ,	docM.t_appr , "


      Sql = Sql & "	Case "

      Sql = Sql & "	when docM.t_cspa in ('50010000', '50010100', '50010300', '50010600') then 	'Drum' "

      Sql = Sql & "	when docM.t_cspa in ('50091200', '50091000', '50090800', '50090700', '50090601', '50090600', '50090500', '50090401', '50090400', '50090302', '50090301', '50090300', '50090202', '50090201', '50090200', '50090101', '50090100', '50090000') then 	'Piping' "

      Sql = Sql & "	When docM.t_cspa In ('50360400', '50360302', '50360301', '50360300', '50020000', '50020100', '50020200', '50020300', '50020400', '50020500', '50020600', '50360200', '50020900', '50021000', '50030000', '50030100', '50030200', '50030300', '50030400', '50030500', '50030600', '50030700', '50030800', '50030900', '50031000', '50031100', '50031200', '50031300', '50031400', '50031500', '50031600', '50032000', '50040000', '50040100', '50040200', '50040300', '50040400', '50040500', '50040600', '50040700', '50041000')  then 	'Tubes' "
      Sql = Sql & "	Else '-' "
      Sql = Sql & "	End As Shop, "

      Sql = Sql & "	TraD.t_tran as TranID , TraH.t_isdt as Tissue, "
      Sql = Sql & "	Case TraH.t_type"
      Sql = Sql & "	when 1 then 'Customer' "
      Sql = Sql & "	When 2 Then 'Internal' "
      Sql = Sql & "	when 3 then 'Site' "
      Sql = Sql & "	When 4 Then 'Vendor' "
      Sql = Sql & "	End As Ttype "
      Sql = Sql & "	From tdmisg001200 As docM "
      Sql = Sql & "	Left Join tdmisg115200 as dcrL on (docM.t_docn = dcrL.t_docd And docM.t_revn = dcrL.t_revn) "
      Sql = Sql & "	Left Join tdmisg132200 as TraD on (docM.t_docn = TraD.t_docn And docM.t_revn = TraD.t_revn) "
      Sql = Sql & "	Left Join tdmisg131200 as TraH on (TraD.t_tran = TraH.t_tran) "
      Sql = Sql & "	Left Join tdmisg114200 as dcrH on dcrL.t_dcrn = dcrH.t_dcrn  "
      Sql = Sql & "		WHERE docM.t_revn = (Select MAX(tmp.t_revn) FROM tdmisg001200 As tmp WHERE tmp.t_docn= docM.t_docn) "
      Sql = Sql & "			And docM.t_cprj = '" & t_cprj & "'"
      Sql = Sql & "			And TraH.t_stat=5 "
      Sql = Sql & "			And docM.t_cspa in ('50010000', '50010100', '50010300', '50010600','50091200', '50091000', '50090800', '50090700', '50090601', '50090600', '50090500', '50090401', '50090400', '50090302', '50090301', '50090300', '50090202', '50090201', '50090200', '50090101', '50090100', '50090000','50360400', '50360302', '50360301', '50360300', '50020000', '50020100', '50020200', '50020300', '50020400', '50020500', '50020600', '50360200', '50020900', '50021000', '50030000', '50030100', '50030200', '50030300', '50030400', '50030500', '50030600', '50030700', '50030800', '50030900', '50031000', '50031100', '50031200', '50031300', '50031400', '50031500', '50031600', '50032000', '50040000', '50040100', '50040200', '50040300', '50040400', '50040500', '50040600', '50040700', '50041000') "

      Sql = Sql & "			AND (docM.t_wfst = 5 OR docM.t_wfst = 7) "
      Sql = Sql & "			AND ((docM.t_wfst = 5 and datediff(d,docM.t_drdt,getdate()) <= " & LastDays & ") or (docM.t_wfst=7 and datediff(d,dcrH.t_appt,getdate()) <=" & LastDays & ")  )"

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.LG.lgDMisg)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgDMisg(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public Function GetEnable() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
	End Class
End Namespace
