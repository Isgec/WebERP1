<script type="text/javascript"> 
var script_erpCreateTPTBill = {
		getIRData: function(o) {
			var value = o;
			var IRNo = $get(o);	
		  if(IRNo.value=='')
		    return false;
		  value = value + ',' + IRNo.value ;
		  IRNo.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  IRNo.style.backgroundRepeat= 'no-repeat';
		  IRNo.style.backgroundPosition = 'right';
		  PageMethods.getIRData(value, this.IRData);
		},
		IRData: function(r){
		  var v=JSON.parse(r);
		  var x = $get(v.tgt);
		  x.style.backgroundImage  = 'none';
		  if(v.err){
		    alert(v.msg);
		    x.value='';
		    x.focus();
		  }else{
		    var pf=v.tgt.substring(0,2);
		    var objVal;
		    objVal = v.irdata;
		    if (typeof(objVal) == 'object') {
		      var aProp = Object.keys(objVal);
		      for (i = 0; i < aProp.length; i++) {
		        try {
		          $get(pf + aProp[i]).value = objVal[aProp[i]];
		        } catch (e) { }
		      }
		      if (pf=='F_')
		        try { $get('D_GRNos').value = objVal.GRNos; } catch (ex) { }
		    }

		  }
		},
		xIRData: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		  	try { $get('L_ErrMsgerpCreateTPTBill').innerHTML = p[2]; } catch (ex) { }
		    o.value='';
		    o.focus();
		  }else{
		    if(p[1]=='F_IRNumber'){
		      try { $get('F_TPTBillNo').value = p[2]; } catch (ex) { }
		      try { $get('F_TPTBillDate').value = p[3]; } catch (ex) { }
		      try { $get('F_GRNOs').value = p[4]; } catch (ex) { }
		      try { $get('F_TPTCode').value = p[5]; } catch (ex) { }
		      try { $get('F_PONumber').value = p[6]; } catch (ex) { }
		      try { $get('F_ProjectID').value = p[7]; } catch (ex) { }
		      try { $get('F_TPTBillAmount').value = p[8]; } catch (ex) { }
		      try { $get('F_TPTBillReceivedOn').value = p[9]; } catch (ex) { }
		      try { $get('F_AssessableValue').value = p[10]; } catch (ex) { }
		      try { $get('F_IGSTRate').value = p[11]; } catch (ex) { }
		      try { $get('F_IGSTAmount').value = p[12]; } catch (ex) { }
		      try { $get('F_CGSTRate').value = p[13]; } catch (ex) { }
		      try { $get('F_CGSTAmount').value = p[14]; } catch (ex) { }
		      try { $get('F_SGSTRate').value = p[15]; } catch (ex) { }
		      try { $get('F_SGSTAmount').value = p[16]; } catch (ex) { }
		      try { $get('F_CessRate').value = p[17]; } catch (ex) { }
		      try { $get('F_CessAmount').value = p[18]; } catch (ex) { }
		      try { $get('F_TotalGST').value = p[19]; } catch (ex) { }
		      try { $get('F_TotalAmount').value = p[20]; } catch (ex) { }

		      try { $get('D_GRNOs').value = p[4]; } catch (ex) { }

		    }else {
		      try { $get('D_TPTBillNo').value = p[2]; } catch (ex) { }
		      try { $get('D_TPTBillDate').value = p[3]; } catch (ex) { }

		      try { $get('D_TPTCode').value = p[5]; } catch (ex) { }
		      try { $get('D_PONumber').value = p[6]; } catch (ex) { }
		      try { $get('D_ProjectID').value = p[7]; } catch (ex) { }
		      try { $get('D_TPTBillAmount').value = p[8]; } catch (ex) { }
		      try { $get('D_TPTBillReceivedOn').value = p[9]; } catch (ex) { }
		      try { $get('D_AssessableValue').value = p[10]; } catch (ex) { }
		      try { $get('D_IGSTRate').value = p[11]; } catch (ex) { }
		      try { $get('D_IGSTAmount').value = p[12]; } catch (ex) { }
		      try { $get('D_CGSTRate').value = p[13]; } catch (ex) { }
		      try { $get('D_CGSTAmount').value = p[14]; } catch (ex) { }
		      try { $get('D_SGSTRate').value = p[15]; } catch (ex) { }
		      try { $get('D_SGSTAmount').value = p[16]; } catch (ex) { }
		      try { $get('D_CessRate').value = p[17]; } catch (ex) { }
		      try { $get('D_CessAmount').value = p[18]; } catch (ex) { }
		      try { $get('D_TotalGST').value = p[19]; } catch (ex) { }
		      try { $get('D_TotalAmount').value = p[20]; } catch (ex) { }
		      }
		  }
		},
		ACETPTCode_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('TPTCode','');
		  var F_TPTCode = $get(sender._element.id);
		  var F_TPTCode_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_TPTCode.value = p[0];
		  F_TPTCode_Display.innerHTML = e.get_text();
		},
		ACETPTCode_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('TPTCode','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACETPTCode_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACEProjectID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('ProjectID','');
		  var F_ProjectID = $get(sender._element.id);
		  var F_ProjectID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_ProjectID.value = p[0];
		  F_ProjectID_Display.innerHTML = e.get_text();
		},
		ACEProjectID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('ProjectID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEProjectID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACEDiscReturnedToByAC_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('DiscReturnedToByAC','');
		  var F_DiscReturnedToByAC = $get(sender._element.id);
		  var F_DiscReturnedToByAC_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_DiscReturnedToByAC.value = p[0];
		  F_DiscReturnedToByAC_Display.innerHTML = e.get_text();
		},
		ACEDiscReturnedToByAC_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('DiscReturnedToByAC','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEDiscReturnedToByAC_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_TPTCode: function(sender) {
		  var Prefix = sender.id.replace('TPTCode','');
		  this.validated_FK_ERP_TransporterBill_TPTCode_main = true;
		  this.validate_FK_ERP_TransporterBill_TPTCode(sender,Prefix);
		  },
		validate_ProjectID: function(sender) {
		  var Prefix = sender.id.replace('ProjectID','');
		  this.validated_FK_ERP_TransporterBill_ProjectID_main = true;
		  this.validate_FK_ERP_TransporterBill_ProjectID(sender,Prefix);
		  },
		validate_DiscReturnedToByAC: function(sender) {
		  var Prefix = sender.id.replace('DiscReturnedToByAC','');
		  this.validated_FK_ERP_TransporterBill_DiscReturnedToByAc_main = true;
		  this.validate_FK_ERP_TransporterBill_DiscReturnedToByAc(sender,Prefix);
		  },
		validate_FK_ERP_TransporterBill_DiscReturnedToByAc: function(o,Prefix) {
		  var value = o.id;
		  var DiscReturnedToByAC = $get(Prefix + 'DiscReturnedToByAC');
		  if(DiscReturnedToByAC.value==''){
		    if(this.validated_FK_ERP_TransporterBill_DiscReturnedToByAc_main){
		      var o_d = $get(Prefix + 'DiscReturnedToByAC' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + DiscReturnedToByAC.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_TransporterBill_DiscReturnedToByAc(value, this.validated_FK_ERP_TransporterBill_DiscReturnedToByAc);
		  },
		validated_FK_ERP_TransporterBill_DiscReturnedToByAc_main: false,
		validated_FK_ERP_TransporterBill_DiscReturnedToByAc: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpCreateTPTBill.validated_FK_ERP_TransporterBill_DiscReturnedToByAc_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_ERP_TransporterBill_ProjectID: function(o,Prefix) {
		  var value = o.id;
		  var ProjectID = $get(Prefix + 'ProjectID');
		  if(ProjectID.value==''){
		    if(this.validated_FK_ERP_TransporterBill_ProjectID_main){
		      var o_d = $get(Prefix + 'ProjectID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ProjectID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_TransporterBill_ProjectID(value, this.validated_FK_ERP_TransporterBill_ProjectID);
		  },
		validated_FK_ERP_TransporterBill_ProjectID_main: false,
		validated_FK_ERP_TransporterBill_ProjectID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpCreateTPTBill.validated_FK_ERP_TransporterBill_ProjectID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_ERP_TransporterBill_TPTCode: function(o,Prefix) {
		  var value = o.id;
		  var TPTCode = $get(Prefix + 'TPTCode');
		  if(TPTCode.value==''){
		    if(this.validated_FK_ERP_TransporterBill_TPTCode_main){
		      var o_d = $get(Prefix + 'TPTCode' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + TPTCode.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_TransporterBill_TPTCode(value, this.validated_FK_ERP_TransporterBill_TPTCode);
		  },
		validated_FK_ERP_TransporterBill_TPTCode_main: false,
		validated_FK_ERP_TransporterBill_TPTCode: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpCreateTPTBill.validated_FK_ERP_TransporterBill_TPTCode_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		ACECreatedBy_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('CreatedBy','');
		  var F_CreatedBy = $get(sender._element.id);
		  var F_CreatedBy_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_CreatedBy.value = p[0];
		  F_CreatedBy_Display.innerHTML = e.get_text();
		},
		ACECreatedBy_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('CreatedBy','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACECreatedBy_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_CreatedBy: function(sender) {
		  var Prefix = sender.id.replace('CreatedBy','');
		  this.validated_FK_ERP_TransporterBill_CreatedBy_main = true;
		  this.validate_FK_ERP_TransporterBill_CreatedBy(sender,Prefix);
		  },
		validate_FK_ERP_TransporterBill_CreatedBy: function(o,Prefix) {
		  var value = o.id;
		  var CreatedBy = $get(Prefix + 'CreatedBy');
		  if(CreatedBy.value==''){
		    if(this.validated_FK_ERP_TransporterBill_CreatedBy_main){
		      var o_d = $get(Prefix + 'CreatedBy' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + CreatedBy.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_TransporterBill_CreatedBy(value, this.validated_FK_ERP_TransporterBill_CreatedBy);
		  },
		validated_FK_ERP_TransporterBill_CreatedBy_main: false,
		validated_FK_ERP_TransporterBill_CreatedBy: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpCreateTPTBill.validated_FK_ERP_TransporterBill_CreatedBy_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		temp: function() {
		}
		}
</script>
