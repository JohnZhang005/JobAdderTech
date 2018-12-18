import React, { Component } from 'react';
import SkillList from './SkillList';

class CandidateSlot extends Component {
    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-md-6">
                        <h3 className="text-primary">{this.props.Name}</h3>
                        <SkillList
                            matchSkills={this.props.matchSkills}
                            skills={this.props.SkillTags}
                        />
                    </div>
                    <div className="col-md-5">
                        <h3 className="text-primary">{(this.props.matchScore * 100).toFixed(1)}</h3>
                    </div>
                </div>
                <hr />
            </div>
        );
    }
}

export default CandidateSlot;