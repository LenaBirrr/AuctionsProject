
$("#ParticipantId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "id",
	searchField: "id",
	placeholder: "Выберите участника",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/Participant/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#Participant option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#ParticipantId").append(
							"<option value=\"" + data[i].id + "\">" +"</option>");
					}

					callback(data);
				}
			}, "json");
	}
});