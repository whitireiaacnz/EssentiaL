 
//function for Checking the Empty Value
function isEmptyCheck(strValue, strErrMsg)
{
	if (Trim(strValue.value)=="")
	{
	    alert(strErrMsg);
		//strValue.focus();
		return false;
	}
	return true;
}
/**************************************************************************************************************/
/* Function To Check only character Not allow Numeric & Special character. By Sweta Naik On 26-Feb-2013       */
/**************************************************************************************************************/

function isOnlyChar(strValue, strErrMsg) {
    var letters = /^[A-Za-z\s]+$/; 
    if (!strValue.value.match(letters)) 
      {
        alert(strErrMsg);
        strValue.focus();
        return false;
    }
    return true;
}
/**************************************************************************************************************/
/* Function To Check only character & Numeric  not allow Special character. By Sweta Naik On 26-Feb-2013       */
/**************************************************************************************************************/

function isalphnumeric(strValue, strErrMsg) {
    var letters = /^[0-9a-zA-Z\s]+$/;
    if (!strValue.value.match(letters)) {
        alert(strErrMsg);
        strValue.focus();
        return false;
    }
    return true;
}

function CheckforEmptyfield(strValue,strErrMsg)
{
    if(Trim(strValue.value)=="")
    {
        return false;
    }
    true;
}

// Function for checking field is numeric
function isNumeric(val){return(parseFloat(val,10)==(val*1));}

function hasSpecialCharacters(psValidate)
{
	var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\"<>?";
	for (i=0; i<=psValidate.length-1; i++) 
	{
		//alert(psValidate.charAt(i)  + "  " + iChars.indexOf(psValidate.charAt(i)));
  		if (iChars.indexOf(psValidate.charAt(i)) != -1) 
  			return false;
	}
	return true;	
}


//Function for chking the Extension of the image is Valid
function isFileExtensionValid(ValueToChk)
{
	
	if (ValueToChk.value !="")
	{
		var strExtension=ValueToChk.value.substring(ValueToChk.value.length,ValueToChk.value.length-3)
		//alert(strExtension.toLowerCase())
		//return false;
		switch(strExtension.toLowerCase())
		{
			case "txt":
				return true;
				break;	
			case "doc":
				return true;
				break;
			case "xls":
				return true;
				break;
			case "pdf":
				return true;
				break;
			case "zip":
				return true;
				break;
			case "rar":
				return true;
				break;
			default:
				return false;
		}
	}
	return true;	
}



function chkLength(strValue, strLength, strErrMsg)
{

	//alert(strValue.value.length); 
	if (Trim(strValue.value).length==0)
	{
		alert("Please Enter a value");
		strValue.focus();
		return false;
	}
	

	if (Trim(strValue.value).length<strLength)
	{
		alert(strErrMsg);
		strValue.focus();
		return false;
	}
	//alert(Trim(strValue))
	if (isNaN(Trim(strValue.value))==true) // || Trim(strValue) == null)
	{
		alert("Please Enter a numeric value!!");
		strValue.focus();
		return false;	
	}


	return true;
}

//function for Checking the Deletion Confirmation


function ConfirmDelete()
{

        return confirm("Are you sure you want to delete this record");
			
			
}

/*function ConfirmDelete(psErr)
{
			return confirm(psErr);
}*/




function chkValues(str1, str2 , strMsg)
{
	if (str1!=str2)
	{
		alert(strMsg);
		return false; 
	}
	return true;
}



function isSpaceEntered(psValue)
{
	for (var i=0;i<psValue.length;i++)
		{
			if((psValue.charAt(i)==" "))
				return false;
		}
		return true;
}

function OpenDialog(strPath)
{
    window.showModalDialog(strPath , strPath, "dialogWidth:1000px; dialogHeight:700px; center:yes");

}
//function for Opening the New Window
function OpenWindow(strPath)
{
    //alert(strPath);
	window.open(strPath, '', 'fullscreen=no,toolbar=no,status=yes,menubar=no,scrollbars=yes,resizable=no,directories=no,location=no,width=601,height=450,Left='+(screen.width-800)/2+',top='+(screen.height-600)/2 );
}

function OpenWindowForEmail(filename,subject,Todate , Fromdate) {
    //alert(strPath);
    window.open('../Reports/Email.aspx?filename=' + filename + '&subject=' + subject +'&Todate=' + Todate  +'&Fromdate='+Fromdate, '', 'fullscreen=no,toolbar=no,status=yes,menubar=no,scrollbars=yes,resizable=no,directories=no,location=no,width=615,height=517,Left=' + (screen.width - 800) / 2 + ',top=' + (screen.height - 600) / 2);
}


function openWindow(strPath, ht, wt)
{	
	window.open(strPath, 'Window', "fullscreen=no,toolbar=no,status=no,menubar=no,scrollbars=no,resizable=no,directories=no,location=no,width=559,height=140,Left=(screen.width-" + wt + ")/2 ,top=(screen.height-" + ht + ")/2");
}

function OpenWindowForPrint(strPath)
{
    window.open(strPath, '', 'fullscreen=No,toolbar=no,status=no,menubar=no,scrollbars=no,resizable=no,titlebar=no,width=900,height=700');
}


//function for Opening the New Window
function OpenWindowGuidelines(strPath)
{
	window.open(strPath, '', 'fullscreen=no,toolbar=no,status=no,menubar=no,scrollbars=yes,resizable=no,directories=no,location=no,width=640,height=640,Left='+(screen.width-640)/2+',top='+(screen.height-640)/2 );
}


//Email Validation
function isEmailValid(str) 
{
	checkEmail = str.value
//this logic allows 2,3 and 4 character domain names
	if ((checkEmail.indexOf('@') < 0) || ((checkEmail.charAt(checkEmail.length-5) != '.')&&
										  (checkEmail.charAt(checkEmail.length-4) != '.') && 
										  (checkEmail.charAt(checkEmail.length-3) != '.'))) 
	{
		alert("Please Enter a Valid Email Address");
		str.focus();
		return false;
	} 
return true;
}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~Chks the Entered value is Number or not..~~~~~~~~~~
//fld -   field name to be checked.
//msg -   error message to be displayed.

function IsEmail(fld, msg) {

    var emailStr = fld.value;

    if (emailStr.toString() == "") {
        alert("Please Enter Email address");
        fld.focus()
        return false;

    }
    else if (emailStr != "") {
        var checkTLD = 1;
        var knownDomsPat = /^(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum)$/;
        var emailPat = /^(.+)@(.+)$/;
        var specialChars = "\\(\\)><@,;:\\\\\\\"\\.\\[\\]";
        var validChars = "\[^\\s" + specialChars + "\]";
        var quotedUser = "(\"[^\"]*\")";
        var ipDomainPat = /^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/;
        var atom = validChars + '+';
        var word = "(" + atom + "|" + quotedUser + ")";
        var userPat = new RegExp("^" + word + "(\\." + word + ")*$");
        var domainPat = new RegExp("^" + atom + "(\\." + atom + ")*$");
        var matchArray = emailStr.match(emailPat);

        if (matchArray == null) {
            alert("Email address seems incorrect (check @ and .'s)");
            fld.focus()
            return false;
        }
        var user = matchArray[1];
        var domain = matchArray[2];
        for (i = 0; i < user.length; i++) {
            if (user.charCodeAt(i) > 127) {
                alert("Email's username contains invalid characters.");
                fld.focus()
                return false;
            }
        }
        for (i = 0; i < domain.length; i++) {
            if (domain.charCodeAt(i) > 127) {
                alert("Email's domain name contains invalid characters.");
                fld.focus()
                return false;
            }
        }
        if (user.match(userPat) == null) {
            alert("Email's username doesn't seem to be valid.");
            fld.focus()
            return false;
        }

        var IPArray = domain.match(ipDomainPat);
        if (IPArray != null) {
            for (var i = 1; i <= 4; i++) {
                if (IPArray[i] > 255) {
                    alert("Email's Destination IP address is invalid!");
                    fld.focus()
                    return false;
                }
            }
            //return true;
        }
        var atomPat = new RegExp("^" + atom + "$");
        var domArr = domain.split(".");
        var len = domArr.length;
        for (i = 0; i < len; i++) {
            if (domArr[i].search(atomPat) == -1) {
                alert("Email's domain name does not seem to be valid.");
                fld.focus()
                return false;
            }
        }


        if (len < 2) {
            alert("Email address is missing a hostname!");
            fld.focus()
            return false;
        }
        //return true;

    }

    return true;

}


//~~~~~~~~~~~~~~~~~~~~~~~~~~~Chks the Entered value is Number or not..~~~~~~~~~~
//CREATED BY: Bhavin
//Version: 1.0
//Created Date: 15-01-2003
//Modified Date:
//Modified By:
function validateNumber(ControlToChk,strmsg)
{
	if (isNaN(ControlToChk.value))
	{
		alert(strmsg);
		ControlToChk.focus();
		return false;	
	}
return true;
}





//~~~~~~~~~~~~~~~~~~~~~~DATE VALIDATION CODE~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//CREATED BY: Bhavin
//Version: 1.0
//Created Date: 15-01-2003
//Modified Date:
//Modified By:
function checkdate(objName) 
{

	var datefield = objName;
	
	if (datefield.value=="")
	{
		alert("Enter Date!!");
		return false;
	}

	
	if (chkdate(objName) == false) 
	{
		datefield.select();
		alert("Invalid Date. Please try again.");
		datefield.focus();
		return false;
	}
	else 
	{
		//alert(chkdate(objName))
		return true;
	}
	
	return;
}


function chkdate(objName) 
{
	var strDatestyle = "US"; //United States date style
	//var strDatestyle = "EU";  //European date style
	var strDate;
	var strDateArray;
	var strDay;
	var strMonth;
	var strYear;
	var intday;
	var intMonth;
	var intYear;
	var booFound = false;
	var datefield = objName;
	var strSeparatorArray = new Array("-"," ","/",".");
	var intElementNr;
	var err = 0;
	/*
	var strMonthArray = new Array(12);
	strMonthArray[0] = "Jan";
	strMonthArray[1] = "Feb";
	strMonthArray[2] = "Mar";
	strMonthArray[3] = "Apr";
	strMonthArray[4] = "May";
	strMonthArray[5] = "Jun";
	strMonthArray[6] = "Jul";
	strMonthArray[7] = "Aug";
	strMonthArray[8] = "Sep";
	strMonthArray[9] = "Oct";
	strMonthArray[10] = "Nov";
	strMonthArray[11] = "Dec";
	*/
	strDate = datefield.value;

	if (strDate.length < 1) 
	{
		return true;
	}	
	
	for (intElementNr = 0; intElementNr < strSeparatorArray.length; intElementNr++) 
	{
	alert(strDate.indexOf(strSeparatorArray[intElementNr]));
		if (strDate.indexOf(strSeparatorArray[intElementNr]) != -1) 
		{
			strDateArray = strDate.split(strSeparatorArray[intElementNr]);
			if (strDateArray.length != 3) 
			{
				err = 1;
				return false;
			}
			else 
			{
				strDay = strDateArray[0];
				strMonth = strDateArray[1];
				strYear = strDateArray[2];
			}
		booFound = true;
		}
	}
	
	if (booFound == false) 
	{
		if (strDate.length>5) 
		{
			strDay = strDate.substr(0, 2);
			strMonth = strDate.substr(2, 2);
			strYear = strDate.substr(4);
		}
	}

		
	if (strYear.length == 2) 
	{
		strYear = '20' + strYear;
	}
	
	// US style
	if (strDatestyle == "US") 
	{
		strTemp = strDay;
		strDay = strMonth;
		strMonth = strTemp;
	}

intday = parseInt(strDay, 10);

	if (isNaN(intday)) 
	{
		err = 2;
		return false;
	}
	
	if(intday == "00")
	{
	  alert("Invalid DATE");
	}

intMonth = parseInt(strMonth, 10);

	if (isNaN(intMonth)) 
	{
		for (i = 0;i<12;i++) 
		{
			/*if (strMonth.toUpperCase() == strMonthArray[i].toUpperCase()) 
			{
				intMonth = i+1;
				strMonth = strMonthArray[i];
				i = 12;
			}*/
		}

		if (isNaN(intMonth)) 
		{
			err = 3;
			return false;
		}
	}

intYear = parseInt(strYear, 10);
	if (isNaN(intYear)) 
	{
		err = 4;
		return false;
	}

	if (intMonth>12 || intMonth<1) 
	{
		err = 5;
		return false;
	}

	if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth 

== 12) && (intday > 31 || intday < 1)) 
	{
		err = 6;
		return false;
	}

	if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30 || intday < 1)) 
	{
		err = 7;
		return false;
	}

	if (intMonth == 2) 
	{
		if (intday < 1) 
		{
			err = 8;
			return false;
		}
		if (LeapYear(intYear) == true) 
		{
			if (intday > 29) 
			{
				err = 9;
				return false;
			}
		}	
		else 
		{
			if (intday > 28) 
			{
				err = 10;
				return false;
			}
		}
	}

	/*if (strDatestyle == "US") 
	{
		datefield.value = strMonthArray[intMonth-1] + " " + intday+" " + strYear;
	}
	else
	{
		datefield.value = intday + " " + strMonthArray[intMonth-1] + " " + strYear;
	}*/
	
return true;
}

function LeapYear(intYear) 
{
	if (intYear % 100 == 0) 
	{
		if (intYear % 400 == 0) 
		{ 
			return true; 
		}
	}
	else 
	{
		if ((intYear % 4) == 0) 
		{ 
			return true; 
		}
	}

return false;
}

function doDateCheck(from, to, objName)
{	
	if (Date.parse(from.value) <= Date.parse(to.value))
	{
		//alert("The dates are valid.");
		return true;
	}
	else
	{
			objName.innerText ="Start date should be less than End date.";
			objName.className = "ErrorMessage";
			//alert("Closing Date should be the same or after the Opening Date.");
			return false;
		//if (from.value == "" || to.value == "") 
		//{
		//	objName.innerText ="Start date should be less than End date.";
		//	objName.className = "ErrorMessage";
			//alert("Closing Date should be the same or after the Opening Date.");
		//	return false;
		//}
	}
}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DATE VALIDATION CODE ENDS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Value Trimming Function ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`
function Trim(strValue)
{
   	return LTrim(RTrim(strValue));
}

function LTrim(strValue)
{
   	var LTRIMrgExp = /^\s */;
   	return strValue.replace(LTRIMrgExp, '');
}

function RTrim(strValue)
{
	var RTRIMrgExp = /\s *$/;
	return strValue.replace(RTRIMrgExp, '');
}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ End of Value Trimming Function ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`




function extractNumber(obj, decimalPlaces, allowNegative)
{
	var temp = obj.value;
	
	// avoid changing things if already formatted correctly
	var reg0Str = '[0-9]*';
	if (decimalPlaces > 0) 
	{
		reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
	} 
	else if (decimalPlaces < 0) 
	{
		reg0Str += '\\.?[0-9]*';
	}
	reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
	reg0Str = reg0Str + '$';
	var reg0 = new RegExp(reg0Str);
	if (reg0.test(temp)) return true;

	// first replace all non numbers
	var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
	var reg1 = new RegExp(reg1Str, 'g');
	temp = temp.replace(reg1, '');

	if (allowNegative) {
		// replace extra negative
		var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
		var reg2 = /-/g;
		temp = temp.replace(reg2, '');
		if (hasNegative) temp = '-' + temp;
	}
	
	if (decimalPlaces != 0) {
		var reg3 = /\./g;
		var reg3Array = reg3.exec(temp);
		if (reg3Array != null) {
			// keep only first occurrence of .
			//  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
			var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
			reg3Right = reg3Right.replace(reg3, '');
			reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
			temp = temp.substring(0,reg3Array.index) + '.' + reg3Right;
		}
	}
	
	obj.value = temp;
}
function blockNonNumbers(obj, e, allowDecimal, allowNegative)
{
	var key;
	var isCtrl = false;
	var keychar;
	var reg;
		
	if(window.event) {
		key = e.keyCode;
		isCtrl = window.event.ctrlKey
	}
	else if(e.which) {
		key = e.which;
		isCtrl = e.ctrlKey;
	}
	
	if (isNaN(key)) return true;
	
	keychar = String.fromCharCode(key);
	
	// check for backspace or delete, or if Ctrl was pressed
	
	if (key == 8 || isCtrl )
	{
		return true;
	}

	reg = /\d/;
	var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
	var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;
	
	return isFirstN || isFirstD || reg.test(keychar);
}




function CheckDecimalInNumber(strValue)
{
				/*if(	strValue.length > 8)
				{
					var i;
					var j;
					
					for(i=0; i < 9; i++)
					{						
						if(((strValue.charAt(i))=='.'))
						 j= 0;							
					}
					
					if(j != 0)
					{						
						return false;
					}				
				}*/
				
				if(	strValue.length == 1)
				{
					if(((strValue.charAt(0))=='.'))
						return false;						
				}
				else
				{
					return true
				}
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Date Validations

var dtCh= "/";
var minYear=1900;
var maxYear=2200;

function isInteger(s)
{
	var i;
    for (i = 0; i < s.length; i++)
   {   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag)
{
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++)
   {   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year)
{
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) 
{
	for (var i = 1; i <= n; i++)
   {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}

function isDate(dtStr,objName)
{
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strMonth=dtStr.substring(0,pos1)
	var strDay=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++)
	{
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1)
	{
		objName.innerText ="The date format should be : mm/dd/yyyy";
		objName.className = "ErrorMessage"; 
		//alert("The date format should be : mm/dd/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12)
	{
		objName.innerText ="Please enter a valid month";
		objName.className = "ErrorMessage"; 
		//alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month])
	{
		objName.innerText ="Please enter a valid day";
		objName.className = "ErrorMessage";
		//alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear)
	{
		objName.innerText ="Please enter a valid 4 digit year between "+minYear+" and "+maxYear;
		objName.className = "ErrorMessage";

		//alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false)
	{
		objName.innerText ="Please enter a valid day";
		objName.className = "ErrorMessage";
		//alert("Please enter a valid date")
		return false
	}
return true
}

// BOI, followed by an optional + or -, followed by one of these two patterns:
// (a) one or more digits, followed by ., followed by zero or more digits
// (b) zero or more digits, followed by ., followed by one or more digits
// ... followed by EOI.
var reSignedFloat = /^(([+-]?\d+(\.\d*)?)|([+-]?(\d*\.)?\d+))$/
var defaultEmptyOK = true

function ShowCalendar(evnt,txtDate) {
	var str="";
	str = "toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=166,height=150,top=" + evnt.screenY + ", left=" + evnt.screenX;

	calendar_window = window.open("../Common/Calendar.aspx?boxname="+txtDate,'calendar_window', str);
	calendar_window.focus();
	return true;
}

function ShowCalculator(evnt,txtAmount) {
			var str="";
			str = "titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=0,width=177,height=190,top=" + evnt.screenY + ", left=" + evnt.screenX;

			calendar_window = window.open("../Common/Calculator.aspx?boxname="+txtAmount,'calculator_window', str);
			calendar_window.focus();
			return true;
}

/* auto tab  */
function CommonAutoTab(FirstID,SecondID,FirstLength) {
	
		var textLen=(document.getElementById(FirstID).value).length; 

		// BUG04537 - need to exit function when tab key, shift+tab pressed
		if ((event.keyCode == 9) || (event.keyCode == 16))
		{
			return;
		}

		if (textLen==FirstLength) 
		{ 
			document.getElementById(SecondID).focus();
			// Pause before returning to prevent "runaway" auto tabbing
			window.setTimeout('return',500);
		}				
}

/* This function is used by the searchprovider.ascx user control*/
function DeselectChecks(c)
			{
				if (c.checked)
					{
						var frm = document.forms[0];
						var len = frm.elements.length;
						for (var i = 0; i < len; i++) 
						{
							var e = frm.elements[i];
							if ((e.id.substr(e.id.length - 11)=='chkSelected') && e.id != c.id )
								{e.checked = false}
						}
					}
					else
					{}
			}
			
		
			/**************************************************************************************************************/

/**************************************************************************************************************/
	// Functions for "intellitype" used in dropdownlist
	// This is a global value to determine which item to select
	var selectedOption = 0;
	var KeyPressEnabled = true;

	function SelectChange(controlID)
	{
		// We use this function to disable any dynamic selecting of the
		// combo-box when the user uses the mouse to select items.
		
		if (KeyPressEnabled)
		{
			document.getElementById(controlID).selectedIndex = selectedOption;
		}
	}
	
	function KeyPress(controlID,hiddenID)
	{
		KeyPressEnabled = true;
		var Drop1 = document.getElementById(controlID);
					
		// event.keyCode contains the ASCII value of the key pressed.
		// Here, we display the value in an input box just for debugging.
		// This is not necessary in your final version.
		//document.getElementById("frmSearchProv").KeyPressed.value = event.keyCode;

		// Keycode 38 and 40 are the up and down arrow buttons, in case the user
		// uses the arrow keys to select items. We reset the value of what they
		// have typed and change the global selected item value.
		if (event.keyCode == 38)
		{
			//document.forms[0].Typed.value = ""; //debugging
			selectedOption = Drop1.selectedIndex - 1;
			return;
		}
		
		if (event.keyCode == 40)
		{
			//document.forms[0].Typed.value = "";
			selectedOption = Drop1.selectedIndex + 1;
			return;
		}

		// Keycode 27 is escape, and Keycode 37 is left arrow
		// so the user can clear out what
		// they have typed so far
		if (event.keyCode == 27)
		{
			Drop1.selectedIndex = 0;
			document.getElementById(hiddenID).value = "";
			return;
		}

		if (event.keyCode == 37)
		{
	 		Drop1.selectedIndex = 0;
	 		document.getElementById(hiddenID).value = "";
	 		return;
		}

		if (event.keyCode == 08)
		{
	 		Drop1.selectedIndex = 0;
	 		event.keyCode = 0;
	 		document.getElementById(hiddenID).value = "";
	 		return;
		}

		// Keycode 32 is a space
		if (event.keyCode != 32)
		{
			// Only process the key if it's a letter or number
			if (event.keyCode < 65 || event.keyCode > 90)
				return;
		}

		// Convert the ASCII keycode value to a character and add the key
		// entered to a "buffer". Normally, this would be a hidden field.
		//document.forms[0].Typed.value += String.fromCharCode(event.keyCode).toLowerCase();
		document.getElementById(hiddenID).value +=String.fromCharCode(event.keyCode).toLowerCase();
		// Loop through the select list to find any matches   
		for (x = 0; x < Drop1.length; x++)
		{
			var OptionText = Drop1.options[x].text;
			var tmpOptionText = "";
			    
			// Loop through the value of each select item, and if there is a
			// match on what they have typed in, set the global variable for that value.
			// The browser will run the onChange event since you typed a key. We'll
			// run SelectChange() in the onChangeEvent just to be sure.
			for (y = 0; y < OptionText.length; y ++)
			{
				tmpOptionText += OptionText.charAt(y).toLowerCase();
				
				if (tmpOptionText == document.getElementById(hiddenID).value)
				{
					Drop1.selectedIndex = x;
					selectedOption = x;
					return;
				}
			}
		}
		
	}
/**************************************************************************************************************/
// Call this function to display date in three separate text boxes  

function ShowCalendar2 ( evnt, txtDateM, txtDateD, txtDateY )
{

	var str="";
	str = "toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=166,height=150,top=" + evnt.screenY + ", left=" + evnt.screenX;

	calendar_window = window.open("../Common/Calendar.aspx?boxname=THREE&txtMonth="+txtDateM+"&txtDay="+txtDateD+"&txtYear="+txtDateY,'calendar_window', str);
	calendar_window.focus();
	return true;
}
/**************************************************************************************************************/
function LimitText (textObj, maxCharacters)
{
	if (textObj.innerText.length >= maxCharacters)
	{
		var theKey = event.keyCode;
		//if over the max, disallow characters that would add
		//allow navigation and deletion (backspace(8),del(8),arrows(37-40))
		if (((theKey >= 32 && theKey <= 126) || (theKey >= 128 && theKey <= 254))&&(theKey!=46&&theKey!=37&&theKey!=38&&theKey!=39&&theKey!=40))
		{
			event.returnValue = false;
		}
	}
}
/**************************************************************************************************************/
/* Function To Check Whether A String Is Numeric Or Not. By Ravi Nippani On 02-Nov-2004.                      */
/**************************************************************************************************************/
function IsNumeric ( strNumber )
{
	var strValidChars = "0123456789.-" ;
	var strChar ;
	var blnResult = true ;

	if ( strNumber.length == 0 )
		return false ;

	if ( strNumber == '-' || strNumber == '.' || strNumber == '$' )
		return false ;

	strNumber = strNumber.toString().replace(/\$|\,/g,'') ;

	for (i = 0 ; i < strNumber.length && blnResult == true ; i++ )
	{
		strChar = strNumber.charAt ( i ) ;
		if ( strValidChars.indexOf ( strChar ) == -1 )
		{
			blnResult = false ;
		}
	}
	return blnResult ;
}
/**************************************************************************************************************/
/* Function To Format A String InTo Currency Format. By Ravi Nippani On 02-Nov-2004.                          */
/**************************************************************************************************************/
function FormatCurrency ( strNumber )
{
	strNumber = strNumber.toString().replace(/\$|\,/g,'') ;

	if ( isNaN ( strNumber ) == true )
		strNumber = "0" ;

	if ( IsNumeric ( strNumber ) == false )
		strNumber = "0" ;

	var sign = ( strNumber == ( strNumber = Math.abs ( strNumber ) ) ) ;
	strNumber = Math.floor ( strNumber * 100 + 0.50000000001 ) ;
	var cents = strNumber % 100 ;
	strNumber = Math.floor ( strNumber / 100 ).toString ( ) ;

	if ( cents < 10 )
		cents = "0" + cents ;

	for ( var i = 0; i < Math.floor ( ( strNumber.length - ( 1 + i ) ) / 3 ) ; i++ )
		strNumber = strNumber.substring ( 0, strNumber.length - ( 4 * i + 3 ) ) + ',' + strNumber.substring ( strNumber.length - ( 4 * i + 3 ) ) ;

	return ( ( ( sign ) ? '' : '-' ) + '$' + strNumber + '.' + cents ) ;
}
/**************************************************************************************************************/
/* Function To Check Whether A String Empty Or Not. By Ravi Nippani On 03-Nov-2004.                           */
/**************************************************************************************************************/
function isEmpty ( s )
{
	return ( ( s == null ) || ( s.length == 0 ) )
}
/**************************************************************************************************************/
/* Function To Check Whether A String Is Numeric Or Not. By Ravi Nippani On 03-Nov-2004.                      */
/**************************************************************************************************************/
function isSignedFloat ( s )
{
	if ( isEmpty ( s ) )
	{
		if ( isSignedFloat.arguments.length == 1 )
		{
			return defaultEmptyOK ;
		}
		else
		{
			return ( isSignedFloat.arguments[1] == true ) ;
		}
	}
	else
	{
		return reSignedFloat.test ( s ) ;
	}
}
/**************************************************************************************************************/
/* Function To Trim A String. By Ravi Nippani On 16-Dec-2004.												  */
/**************************************************************************************************************/
function Trim ( strString )
{
	// Remove Leading Spaces And Carriage Returns.
	while ( ( strString.substring ( 0, 1 ) == ' ') || ( strString.substring ( 0, 1 ) == '\n') || ( strString.substring ( 0, 1 ) == '\r' ) )
	{
		strString = strString.substring ( 1, strString.length ) ;
	}

	// Remove Trailing Spaces And Carriage Returns.
	while ( ( strString.substring ( strString.length - 1, strString.length ) == ' ') || ( strString.substring ( strString.length - 1, strString.length ) == '\n') || ( strString.substring ( strString.length - 1, strString.length ) == '\r' ) )
	{
		strString = strString.substring ( 0, strString.length - 1 ) ;
	}

	return ( strString ) ;
}

/**************************************************************************************************************/
/* Function To Compare FromDate <= ToDate 
/* It Require customParse(str) function & str = textbox value in dd-mmm-yyyy format
/**************************************************************************************************************/


function customParse(str) {
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
 n = months.length, re = /(\d{2})-([a-z]{3})-(\d{4})/i, matches;

    while (n--) { months[months[n]] = n; } // map month names to their index :)

    matches = str.match(re); // extract date parts from string

    return new Date(matches[3], months[matches[2]], matches[1]);
} 

  
function CompareFromToDate(from, to, message) {


    //alert(from);
   // var fromdate = document.getElementById("<%=txtFromDate.ClientID%>").value;
   // var todate = document.getElementById("<%=txtToDate.ClientID%>").value;
    if (customParse(from) <= customParse(to)) {
        return true;
    }
    else {
        alert('From date should always be less than or equal to To date');
        return false;
    }

}


function validateEmail(incomingString, strErrMsg) {
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    var companyEmail = incomingString.value;

    if (emailPattern.test(companyEmail)) {
        return true;
    }
    else {
        alert(strErrMsg);
    }
}