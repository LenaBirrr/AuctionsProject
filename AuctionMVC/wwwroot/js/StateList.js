
$("#StateId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "name",
	searchField: "name",
	placeholder: "Выберите состояние",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/State/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#StateId option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#StateId").append(
							"<option value=\"" + data[i].id + "\">" +
							data[i].name + "</option>");
					}

					callback(data);
				}
			}, "json");
	}
});