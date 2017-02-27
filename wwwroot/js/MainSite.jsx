const imgStyle = {
    height: 242,
    width: 200
};

var MainPage = React.createClass({
    getInitialState: function() {
        return {events: []};
    },
    loadEventsFromServer: function(){
      var xhr = new XMLHttpRequest();
		xhr.open('get', this.props.url, true);
		xhr.onload = function () {
			var data = JSON.parse(xhr.responseText);
			this.setState({ events: data });
		}.bind(this);
		xhr.send();  
    },
    componentDidMount: function () {
		window.setInterval(this.loadEventsFromServer, this.props.pollInterval);
	},
    render: function(){
        return (
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-header">
                        <h1 classID="typography">Counter Strinke: Gloabl Offensive Event Counter</h1>
                    </div>
                    <EventList data={this.state.events}/>
                </div>
            </div>
        );
    }
});

var EventList = React.createClass({
    render: function(){
        var eventNodes = this.props.data.map(function(event){
            return (
                <Event key={event.id} name={event.name} date={event.date} venue={event.venue} organizer={event.organizer} />
            );
        });
        return (
            <div>
                {eventNodes}
                <NewEvent />
            </div>
        )
    }
});

var NewEvent = React.createClass({
    render: function(){
        return(
            <div class="col-sm-6 col-md-3">
                <div class="thumbnail">
                    <img style={imgStyle} 
                        src="http://iconshow.me/media/images/Mixed/Free-Flat-UI-Icons/png/512/plus-24-512.png"
                    />
                    <div class="caption">
                        <p><a href="/event/new" class="btn btn-success center-block" role="button">New Event</a></p>
                    </div>
                </div>
            </div>
        );
    }
});

var Event = React.createClass({
    render: function(){
        return (
            <div class="col-sm-6 col-md-3">
                <div class="thumbnail">
                    <img style={imgStyle} src={this.props.organizer.logo} />
                    <div class="caption">
                        <h3>{this.props.name}</h3>
                        <p>Venue: {this.props.venue}</p>
                        <p>Date: {this.props.date}</p>
                        <p>Organizer: {this.props.organizer.name}</p>
                        <p><a href="#" class="btn btn-success center-block" role="button">Choose</a></p>
                    </div>
                </div>
            </div>
        );
    }
});

ReactDOM.render(
    <MainPage url="/events" pollInterval={1000} />,
    document.getElementById('content')
)