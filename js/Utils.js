
function getCodeVal(sCode) {
    var sVal = "";
    switch (sCode) {
    case 1001:
        sVal = '目录功能';
    	break;
    case 1002:
        sVal = '目录功能';
    	break;
    case 2001:
        sVal = '正常';
    	break;
    case 2002:
        sVal = '停用';
    	break;
    default:
        sVal = '未知';
    }
    return sVal;
}