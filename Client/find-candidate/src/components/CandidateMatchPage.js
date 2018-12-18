import React, { Component } from 'react';
import Pagination from './Pagination';
import CandidateSlot from './CandidateSlot';

class CandidateMatchPage extends Component {
    render() {
        if (this.props.currentPage !== "jobCandidate") {
            return "";
        }
        if (this.props.candidates != null) {
            return (
                <div className="container">
                    <h1 className="my-4">{this.props.selectedJob.Name}
                        <small>-{this.props.selectedJob.Company}</small>
                    </h1>
                    <h5>{this.props.selectedJob.Skills}</h5>
                    <hr />
                    {this.props.candidates.map(candidate => (
                        <CandidateSlot
                            key={candidate.CandidateId}
                            Name={candidate.Name}
                            SkillTags={candidate.SkillTags}
                            matchSkills={this.props.selectedJob.Skills}
                            matchScore={candidate.JobMatchScore}
                        />
                        ))}

                    <Pagination
                        pageCount={this.props.pageCount}
                        pageSelected={this.props.pageSelected}
                        jobId={this.props.selectedJob.JobId}
                        findCandidates={this.props.findCandidates}
                    />
                </div>
            );
        } else {
            return <div className="container">Loading...</div>
        }
    }
}

export default CandidateMatchPage;