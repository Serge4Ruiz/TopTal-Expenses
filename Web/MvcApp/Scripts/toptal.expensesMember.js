$(document).ready(function () {
	//var sourceUrl = "http://localhost:54000/api/member/" + sessionStorage.getItem("userName");
	//var result = $.get(sourceUrl, function () {
	//	$("#MemberList").text(result.responseText);
	//});
});

var getWeeklyReport = function () {
	$("#Error").text('');
	$("#ExpenseList").text('');
	var date = $("#WeeklyReportDate").val();
	var token = sessionStorage.getItem('tokenKey');
	var headers = {};
	if (token) { headers.Authorization = 'Bearer ' + token };
	var userName = sessionStorage.getItem('userName');
	var request = $.ajax({
		type: 'GET',
		url: 'http://localhost:54000/api/MemberExpenseByWeek/?UserName=' + userName + '&Date=' + date,
		headers: headers,
		contentType: 'application/json; charset=utf-8'
	});
	request.done(function (data) {
		$("#ExpenseList").text(request.responseText);
	});
	request.fail(function () {
		$("#Error").text('error');
	});
}

var addSingleExpense = function () {
	$("#Error").text('');
	var data = $("#AddExpense").serialize();
	var token = sessionStorage.getItem('tokenKey');
	var headers = {};
	if (token) { headers.Authorization = 'Bearer ' + token };
	var userName = sessionStorage.getItem('userName');
	data = "UserName=" + userName + "&" + data;
	var request = $.ajax({
		type: 'POST',
		url: 'http://localhost:54000/api/MemberExpenses/',
		headers: headers,
		contentType: 'application/json; charset=utf-8'
	});
	request.done(function (data) {
		$("#ExpenseList").text(request.responseText);
	});
	request.fail(function () {
		$("#Error").text('error');
	});
	return false;
}
	