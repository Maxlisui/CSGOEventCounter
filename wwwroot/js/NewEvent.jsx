import {browserHistory} from 'react-router'

var MainPage = React.createClass({
    getInitialState: function(){
        return {
            name:  "",
            date: "",
            venue: "",
            organizerID: 0,
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
    handleEventSubmit: function(e){
        e.preventDefault();
        var name = this.state.name.trim();
        var date = this.state.date.trim();
        var venue = this.state.venue.trim();
        var organizerID = this.state.organizerID;
        if(!name || !date || !venue){
            return;
        }
        
        var data = new FormData();
        data.append('name', name);
        data.append('date', date);
        data.append('venue', venue);
        data.append('organizerID', organizerID);

        var xhr = new XMLHttpRequest();
        xhr.open('post', "/event/add", true);
        xhr.send(data);

        Router.browserHistory.push("/");
    },
    handleOrganizerChange: function(e){
        e.preventDefault();
        this.setState({organizerID: e.target.value});
    },
    render: function(){
        return (
            <div class="row">
                <div class="col-lg-12">
                    <h1>Create a new Event</h1>
                    <div class="well bs-component">
                        <form class="form-horizontal" onSubmit={this.handleEventSubmit} >
                            <fieldset>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Name</label>
                                    <div class="col-lg-10">
                                        <input 
                                            type="text" 
                                            class="form-control" 
                                            placeholder="Name" 
                                            value={this.state.name}
                                            onChange={this.handleNameChange} 
                                        />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Date</label>
                                    <div class="col-lg-10">
                                        <input type="date" 
                                            class="form-control" 
                                            placeholder="Date" 
                                            value={this.state.date}
                                            onChange={this.handleDateChange}
                                         />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Venue</label>
                                    <div class="col-lg-10">
                                        <input 
                                            type="text" 
                                            class="form-control" 
                                            placeholder="Venue" 
                                            value={this.state.venue} 
                                            onChange={this.handleVenueChange}
                                        />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Organizer</label>
                                    <div class="col-lg-10">
                                        <OptionList organizer={this.state.organizer} handler={this.handleOrganizerChange}/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-10 col-lg-offset-2">
                                        <button type="submit" class="btn btn-primary center-block">Submit</button>
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
                <option key={organizer.id} value={organizer.id}>{organizer.name}</option>
            );
        });
        return (
            <select class="form-control" onChange={this.props.handler}> 
                {optionNodes}
            </select>
        )
    }
});

ReactDOM.render(
    <MainPage url="/event/organizer" pollInterval={1000} />,
    document.getElementById('content')
)