var userName;

var login = function () {
	$("#Error").text('');
	var tokenUrl = "/Token";
	var loginData = $("#Login").serialize();
	loginData = loginData + "&grant_type=password";
	var result = $.post(tokenUrl, loginData).always(function () {
		if (result.status == 200) {
			var json = $.parseJSON(result.responseText);
			sessionStorage.setItem('tokenKey', json.access_token)
			sessionStorage.setItem('userName', json.userName);
			userName = json.userName;
			$("#UserName").text(json.userName);
			//displayExpenses();
		} else {
			$("#Error").text(result.responseText);
		}
	});
	return false;
}

var getWeeklyReport = function () {
	$("#Error").text('');
	$("#ExpenseList").text('');
	var date = $("#WeeklyReportDate").val();
	var request = $.ajax({
		type: 'GET',
		url: '/api/MemberExpenseByWeek/?UserName=' + userName + '&Date=' + date,
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
	data = "UserName=" + userName + "&" + data;
	var result = $.post('/api/MemberExpenses/', data).always(function () {
		if (result.status == 200) {

		} else {
			$("#Error").text(result.responseText);
		}
	});
	return false;
}

var displayExpenses = function () {
	$("#Error").text('');
	$("#ExpenseList").text('');
	var data = "{ userName: '" + userName + "' }";
	var result = $.post('/api/member/GetById', data).always(function () {
		if (result.status == 200) {
			var container = $("#ExpenseList");
			$.each($.parseJSON(result).Expenses, function (index, value) {
				var amount = value.Amount;
				var description = value.Description;
				var comment = value.Comment;
				var date = value.Date;
				var item = '<li class="list-group-item"><span class="badge" style="font-size: 14pt;">#amount</span>#description<div style="font-size: 9pt; font-style: italic;">#comment</div><div style="font-size: 9pt;"><b>Expense date:</b>#date</div></li>';
				container.append(item.replace('#amount', amount).replace('#description', description).replace('#comment', comment).replace('#date', date));
			});
		} else {
			$("#Error").text(result.responseText);
		}
	});
}

var showUserInfo = function () {
	var token = sessionStorage.getItem('tokenKey');
	var userName = sessionStorage.getItem('userName');
	if (token) {
		$("#UserNameDisplay").text(userName);
		$("#UserInfo").show();
		$("#Access").hide();
	} else {
		$("#UserInfo").hide();
		$("#Access").show();
	}
}

var logout = function () {
	sessionStorage.removeItem('tokenKey');
	sessionStorage.removeItem('userName');
	window.location = '/';
}

var addExpense = function () {
	var response = $.ajax(
		);
}

var getHeaders = function () {
	var token = sessionStorage.getItem('tokenKey');
	if (token) {
		return { "Authorization": "Bearer " + token };
	}
}
