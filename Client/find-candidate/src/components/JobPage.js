import React, { Component } from 'react';
import JobSlot from './JobSlot';

class JobPage extends Component {
    render() {
        if (this.props.currentPage !== "Jobs") {
            return ("");
        }
        if (this.props.jobs !== null) {
            return (
                <div className="container">
                    <h1 className="my-4">All Jobs
                            <small> Find Best Candidate</small>
                    </h1>
                    <hr />
                    {this.props.jobs.map(job => (
                        <JobSlot
                            key={job.JobId}
                            JobId={job.JobId}
                            jobName={job.Name}
                            companyName={job.Company}
                            skills={job.Skills}
                            findCandidates={this.props.findCandidates}
                        />
                    ))}
                </div>
            );
        } else {
            return <div class="container">Loading...</div>
        }
    }
}

export default JobPage;