import React, { Component } from 'react';

class JobSlot extends Component {
    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-6">
                        <h3>{this.props.jobName}</h3>
                        <p>{this.props.companyName}</p>
                        <p>{this.props.skills}</p>
                        <button type="button" className="btn btn-primary" onClick={() => this.props.findCandidates(this.props.JobId, 1)}>Find Candidates</button>
                    </div>
                </div>
                <hr />
            </div>
        );
    }
}

export default JobSlot;