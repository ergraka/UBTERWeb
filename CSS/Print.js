function PrintWin() {
    var DocumentContainer = document.getElementById('divPrint');
    var WindowObject = window.open('', 'PrintWindow', 'width=730,height=330,top=' + '20%' + ',left=' + '15%' + ',toolbars=no,scrollbars=yes,status=no,resizable=yes');
    WindowObject.document.writeln("<html><head><link href='../Styles/Site.css' type='text/css' rel='stylesheet' /></head><body>" + DocumentContainer.innerHTML + "</body></html>");
    WindowObject.document.close();
    WindowObject.focus();
    WindowObject.print();
    WindowObject.close();
}