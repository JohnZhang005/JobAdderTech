import React, { Component } from 'react';

class SkillList extends Component {
    render() {
        let matchLists = this.props.matchSkills.split(",").map(item => item.trim());
        let skills = this.props.skills.split(",").map(item => item.trim());
        let result = [];
        let SkillLength = skills.length;
        skills.forEach((skill, i) => {
            let color;
            if (matchLists.indexOf(skill) >= 0) {
                color = "text-danger"
            }
            if (SkillLength === i + 1) {
                result.push(<span className={color} key={i}>{skill}</span>)
            } else {
                result.push(<span className={color} key={i}>{skill}, </span>)
            }
        })
        return (
            result
        );
    }
}

export default SkillList;