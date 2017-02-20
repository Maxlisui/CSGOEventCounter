var MainPage = React.createClass({
    getInitialState: function(){
        return {
            name:  "",
            date: "",
            venue: "",
            organizerId: 0
        };
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
                                        <input type="text" className="form-control" placeholder="Name" value={this.state.name} />
                                    </div>
                                </div>
                                <div className="form-group">
                                    <label className="col-lg-2 control-label">Date</label>
                                    <div className="col-lg-10">
                                        <input type="date" className="form-control" placeholder="Date" value={this.state.name} />
                                    </div>
                                </div>
                                <div className="form-group">
                                    <label className="col-lg-2 control-label">Venue</label>
                                    <div className="col-lg-10">
                                        <input type="text" className="form-control" placeholder="Venue" value={this.state.name} />
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

ReactDOM.render(
    <MainPage />,
    document.getElementById('content')
)