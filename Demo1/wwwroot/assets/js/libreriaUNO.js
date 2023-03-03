var data = [
    "Albania",
    "Andorra",
    "Armenia",
    "Austria",
    "Azerbaijan",
    "Belarus",
    "Belgium",
    "Bosnia & Herzegovina",
    "Bulgaria",
    "Croatia",
    "Cyprus",
    "Czech Republic",
    "Denmark",
    "Estonia",
    "Finland",
    "France",
    "Georgia",
    "Germany",
    "Greece",
    "Hungary",
    "Iceland",
    "Ireland",
    "Italy",
    "Kosovo",
    "Latvia",
    "Liechtenstein",
    "Lithuania",
    "Luxembourg",
    "Macedonia",
    "Malta",
    "Moldova",
    "Monaco",
    "Montenegro",
    "Netherlands",
    "Norway",
    "Poland",
    "Portugal",
    "Romania",
    "Russia",
    "San Marino",
    "Serbia",
    "Slovakia",
    "Slovenia",
    "Spain",
    "Sweden",
    "Switzerland",
    "Turkey",
    "Ukraine",
    "United Kingdom",
    "Vatican City"
];

if (document.getElementById('choices-state')) {
    var element = document.getElementById('choices-state');
    const example = new Choices(element, {
        searchEnabled: false
    });
};

if (document.getElementById('choices-gender')) {
    var gender = document.getElementById('choices-gender');
    const example = new Choices(gender);
}

if (document.getElementById('choices-year')) {
    var year = document.getElementById('choices-year');
    setTimeout(function () {
        const example = new Choices(year);
    }, 1);

    for (y = 1900; y <= 2020; y++) {
        var optn = document.createElement("OPTION");
        optn.text = y;
        optn.value = y;

        if (y == 2020) {
            optn.selected = true;
        }

        year.options.add(optn);
    }
}

if (document.getElementById('choices-day')) {
    var day = document.getElementById('choices-day');
    setTimeout(function () {
        const example = new Choices(day);
    }, 1);


    for (y = 1; y <= 31; y++) {
        var optn = document.createElement("OPTION");
        optn.text = y;
        optn.value = y;

        if (y == 1) {
            optn.selected = true;
        }

        day.options.add(optn);
    }

}

if (document.getElementById('choices-month')) {
    var month = document.getElementById('choices-month');
    setTimeout(function () {
        const example = new Choices(month);
    }, 1);

    var d = new Date();
    var monthArray = new Array();
    monthArray[0] = "January";
    monthArray[1] = "February";
    monthArray[2] = "March";
    monthArray[3] = "April";
    monthArray[4] = "May";
    monthArray[5] = "June";
    monthArray[6] = "July";
    monthArray[7] = "August";
    monthArray[8] = "September";
    monthArray[9] = "October";
    monthArray[10] = "November";
    monthArray[11] = "December";
    for (m = 0; m <= 11; m++) {
        var optn = document.createElement("OPTION");
        optn.text = monthArray[m];
        // server side month start from one
        optn.value = (m + 1);
        // if june selected
        if (m == 1) {
            optn.selected = true;
        }
        month.options.add(optn);
    }
}
