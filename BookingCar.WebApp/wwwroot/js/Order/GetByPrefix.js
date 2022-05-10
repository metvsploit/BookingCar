function GetByPrefix(prefix) {
    $.post("/Order/GetByPrefix", { prefix: prefix }).done(function (data) {
        $("#drivers").empty();
        for (let person in data) {
            let name = `${data[person].lastName} ${data[person].firstName} ${data[person].patronymic}`;
            $("#drivers").append(`<option value='${name}'></option>`);
        }
    });
}