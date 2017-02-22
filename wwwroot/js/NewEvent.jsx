var MainPage = React.createClass({
    getInitialState: function(){
        return {
            name:  "",
            date: "",
            venue: "",
            organizerId: 0,
            organizer: []
        };
    },
    loadOrganizerFromServer: function(){
      var xhr = new XMLHttpRequest();
		xhr.open('get', this.props.url, true);
		xhr.onload = function () {
			var data = JSON.parse(xhr.responseText);
			this.setState({ organizer: data });
		}.bind(this);
		xhr.send();  
    },
    componentDidMount: function () {
		window.setInterval(this.loadOrganizerFromServer, this.props.pollInterval);
	},
    handleNameChange: function(e){
        this.setState({name: e.target.value});
    },
    handleDateChange: function(e){
        this.setState({date: e.target.value});
    },
    handleVenueChange: function(e){
        this.setState({venue: e.target.value});
    },
    render: function(){
        return (
            <div className="row">
                <div className="col-lg-12">
                    <h1>Create a new Event</h1>
                    <div className="well bs-component">
                        <form className="form-horizontal">
                            <fieldset>
                                <div className="form-group">
                                    <label className="col-lg-2 control-label">Name</label>
                                    <div className="col-lg-10">
                                        <input 
                                            type="text" 
                                            className="form-control" 
                                            placeholder="Name" 
                                            value={this.state.name}
                                            onChange={this.handleNameChange} 
                                        />
                                    </div>
                                </div>
                                <div className="form-group">
                                    <label className="col-lg-2 control-label">Date</label>
                                    <div className="col-lg-10">
                                        <input type="date" 
                                            className="form-control" 
                                            placeholder="Date" 
                                            value={this.state.date}
                                            onChange={this.handleDateChange}
                                         />
                                    </div>
                                </div>
                                <div className="form-group">
                                    <label className="col-lg-2 control-label">Venue</label>
                                    <div className="col-lg-10">
                                        <input 
                                            type="text" 
                                            className="form-control" 
                                            placeholder="Venue" 
                                            value={this.state.venue} 
                                            onChange={this.handleVenueChange}
                                        />
                                    </div>
                                </div>
                                <div className="form-group">
                                    <label className="col-lg-2 control-label">Organizer</label>
                                    <div className="col-lg-10">
                                        <OptionList organizer={this.state.organizer} />
                                    </div>
                                </div>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
});

var OptionList = React.createClass({
    render: function(){
        var optionNodes = this.props.organizer.map(function(organizer){
            return (
                <option>{this.props.organizer.name}</option>
            );
        });
        return (
            <select className="form-control">
                {optionNodes}
            </select>
        )
    }
});

ReactDOM.render(
    <MainPage url="/event/organizer" pollInterval={1000} />,
    document.getElementById('content')
)