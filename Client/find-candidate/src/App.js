import React, { Component } from 'react';
import './App.css';
import Navbar from './components/Navbar';
import JobPage from './components/JobPage';
import Footer from './components/Footer'
import CandidateMatchPage from './components/CandidateMatchPage';

class App extends Component {
	constructor(props) {
		super(props);
		this.state = {
			selectedJob: null,
			currentPage: "Jobs",

			jobs: [],
			matchCandidates: [],

			pageCount: 0,
			pageSelected: 1
		};
		this.listJobs = this.listJobs.bind(this);
		this.findCandidates = this.findCandidates.bind(this);
		this.fetchJobs = this.fetchJobs.bind(this);
		this.fetchCandidates = this.fetchCandidates.bind(this);
	}

	componentDidMount() {
		this.fetchJobs();
	}

	render() {
		return (
			<div className="fullScreen">
				<div className="wrapper">
					<Navbar
						onClick={() => this.listJobs()}
					/>
					<CandidateMatchPage
						currentPage={this.state.currentPage}
						selectedJob={this.state.selectedJob}
						candidates={this.state.matchCandidates}
						pageCount={this.state.pageCount}
						pageSelected={this.state.pageSelected}
						findCandidates={this.findCandidates}
					/>
					<JobPage
						jobs={this.state.jobs}
						currentPage={this.state.currentPage}
						findCandidates={this.findCandidates}
					/>
					<div className="push"></div>
				</div>
				<Footer />
			</div>
		);
	}

	listJobs() {
		this.setState({
			selectedJob: null,
			currentPage: "Jobs"
		})
	}

	findCandidates(id, page) {
		this.setState({
			selectedJob: null,
			currentPage: "jobCandidate"
		});
		this.fetchCandidates(id, page);
	}

	fetchJobs() {
		fetch("http://localhost:60319/api/jobs")
			.then(res => res.json())
			.then(
				(result) => {
					this.setState({
						jobs: result.jobs
					});
				},
				(errors) => {
					console.log(errors)
				}
			)
	}

	fetchCandidates(id, page) {
		var url = "http://localhost:60319/api/jobs/" + id;
		if (page) {
			url += "/" + page;
		}
		this.setState({
			selectedJob: this.state.jobs[id - 1]
		})
		fetch(url)
			.then(res => res.json())
			.then(
				(result) => {
					this.setState({
						pageCount: result.totalPages,
						pageSelected: page,
						matchCandidates: result.candidates
					});
				},
				(errors) => {
					console.log(errors)
				}
			)
	}
}

export default App;
