function updateStatistics(){
    var xhttp = new XMLHttpRequest();
    var name = document.getElementById("name").value;
    console.log(name);
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            var json = JSON.parse(this.responseText);
            console.log(json);
            var tableBody = document.getElementById("tableBody");
            var newTable = "";
            for(var i in json){
                newTable += "<tr>";
                newTable += "<td>"+ json[i].event +"</td>"
                newTable += "<td>"+ json[i].team1 +"</td>"
                newTable += "<td>"+ json[i].team2 +"</td>"
                newTable += "<td>"+ json[i].score +"</td>"
                newTable += "</tr>";
            }
            tableBody.innerHTML = newTable;
        }
    };
    if(name){
        xhttp.open("GET", "/Team/UpdateStatistics?name=" + name, true);
        xhttp.send();
    }
    else{
        xhttp.open("GET", "/Team/UpdateAllStatistics", true);
        xhttp.send();
    }
}