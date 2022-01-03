/*class PersonBox extends React.Component {
    render() {
        return (
            <div className="personBox">Hello, world! I am a person box! </div>
        );
    }
}

ReactDOM.render(<PersonBox />, document.getElementById('content'));*/

/*var PersonGridRow = React.createClass({
    render: function () {
        return (
            <tr>
                <td>{this.props.item.FirstName}</td>
                <td>{this.props.item.LastName}</td>
                <td>{this.props.item.Phonenumber}</td>
                <td>{this.props.item.City}</td>
            </tr>
        );
    }
});

var PersonGridTable = React.createClass({
    getInitialState: function () {
        return {
            items: []
        }
    },
    componentDidMount: function () {
        @* Fetch data via ajax *@
        $.get(this.props.dataUrl, function (data) {
            if (this.isMounted()) {
                this.setState({
                    items: data
                });
            }
        }.bind(this));
    },
    render: function () {
        var rows = [];
        this.state.items.forEach(function (item) {
            rows.push(<PersonGridRow key={item.SSN} item={item} />);
        });
        return (<table className="table table-bordered table-responsive">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Phonenumber</th>
                    <th>City</th>
                </tr>
            </thead>
            <tbody>
                {rows}
            </tbody>
        </table>);
    }
});
ReactDOM.render(
    <PersonGridTable dataUrl="/home/getPersonData" />,
    document.getElementById('griddata')
);*/