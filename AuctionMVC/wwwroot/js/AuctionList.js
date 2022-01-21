
$("#AuctionId").selectize({
	plugins: ["remove_button"],
	valueField: "id",
	labelField: "id",
	searchField: "id",
	placeholder: "Выберите аукцион",
	options: [],
	persist: false,
	create: false,

	load: function (query, callback) {
		if (!query.length) {
			return callback();
		}

		$.get("/api/Auction/find/" + query,
			function (data) {
				if (data.length > 0) {
					$("#Auction option").remove();

					for (var i = 0; i < data.length; i++) {
						$("#AuctionId").append(
							"<option value=\"" + data[i].id + "\">" +"</option>");
					}

					callback(data);
				}
			}, "json");
	}
});