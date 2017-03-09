var team1Score = 0;
var team2Score = 0;

function increaseValue(id)
{
    document.getElementById(id).setAttribute('value', document.getElementById(id).value++);

    if(id === 'team1attackedAsuccess' || id === 'team1attckedBsuccess' || id === 'team1retakeB' || id === 'team1retakeA'){
        team1Score++;
    }
    if(id === 'team2attackedAsuccess' || id === 'team2attckedBsuccess' || id === 'team2retakeB' || id === 'team2retakeA'){
        team2Score++;
    }

    document.getElementById("score").innerHTML = "Score: " + team1Score + " - " + team2Score;
    document.getElementById("scoreTeam1").setAttribute('value', team1Score);
    document.getElementById("scoreTeam2").setAttribute('value', team2Score);
}