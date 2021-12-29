class PersonBox extends React.Component {
    render() {
        return (
            <div className="personBox">Hello, world! I am a person box! </div>
        );
    }
}

ReactDOM.render(<PersonBox />, document.getElementById('content'));