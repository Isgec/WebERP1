<script type="text/javascript"> 
var script_erpProcessTPTBill = {
		getIRData: function(o,p) {
			var value = o;
			var IRNo = $get(o);	
			var Prj = $get(p);	
			if(IRNo.value=='')
		    return false;
		  value = value + ',' + IRNo.value ;
		  IRNo.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  IRNo.style.backgroundRepeat= 'no-repeat';
		  IRNo.style.backgroundPosition = 'right';
		  PageMethods.getPaymentData(value+','+Prj.value, this.IRData);
		},
		IRData: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		  	try { $get('L_ErrMsgerpCreateTPTBill').innerHTML = p[2]; } catch (ex) { }
		    o.value='';
		    o.focus();
		  }else{
		    try { $get('F_PTRNo').value = p[2]; } catch (ex) { }
		    try { $get('F_PTRAmount').value = p[3]; } catch (ex) { }
		    try { $get('F_PTRDate').value = p[4]; } catch (ex) { }
		    try { $get('F_BankVCHNo').value = p[5]; } catch (ex) { }
		    try { $get('F_BankVCHAmount').value = p[6]; } catch (ex) { }
		    try { $get('F_BankVCHDate').value = p[7]; } catch (ex) { }
		 }
		},
		temp: function() {
		}
		}
</script>
