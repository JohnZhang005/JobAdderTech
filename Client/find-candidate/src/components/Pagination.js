import React, { Component } from 'react';

class Pagination extends Component {

	render() {
		let DISPLAY_COUNT = 5;
		let result = [];
		if (this.props.pageSelected > 1) {
			result.push(
				<li key={-1} className="page-item">
					<a className="page-link" href="#top" onMouseDown={e => e.preventDefault()} onClick={() => this.props.findCandidates(this.props.jobId, this.props.pageSelected - 1)} aria-label="Previous">
						<span aria-hidden="true">&laquo;</span>
						<span className="sr-only">Previous</span>
					</a>
				</li>
			);
		}
		let pageMul = parseInt((this.props.pageSelected - 1) / DISPLAY_COUNT, 10);
		for (var i = 0; i < DISPLAY_COUNT; ++i) {
			let pageNum = pageMul * DISPLAY_COUNT + i + 1;
			if (pageNum > this.props.pageCount) {
				break;
			}
			if (pageNum === this.props.pageSelected) {
				result.push(
					<li key={i} className="page-item active">
						<a className="page-link" href="#top">{pageNum}</a>
					</li>
				);
			} else {
				result.push(
					<li key={i} className="page-item">
						<a className="page-link" href="#top" onMouseDown={e => e.preventDefault()} onClick={() => this.props.findCandidates(this.props.jobId, pageNum)}>{pageNum}</a>
					</li>
				);
			}
		}

		if (this.props.pageSelected < this.props.pageCount) {
			result.push(
				<li key={i} className="page-item">
					<a className="page-link" href="#top" onMouseDown={e => e.preventDefault()} onClick={() => this.props.findCandidates(this.props.jobId, this.props.pageSelected + 1)} aria-label="Next">
						<span aria-hidden="true">&raquo;</span>
						<span className="sr-only">Next</span>
					</a>
				</li>
			);
		}

		return (
			<div>
				<ul className="pagination justify-content-center">
					{result}
				</ul>
			</div>

		);
	}
}

export default Pagination;