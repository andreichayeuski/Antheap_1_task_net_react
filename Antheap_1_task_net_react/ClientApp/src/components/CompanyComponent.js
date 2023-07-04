import React, { Component } from 'react';
import moment from 'moment';
import TextareaAutosize from 'react-textarea-autosize';
import { HttpStatusCodesEnum } from '../enums/HttpStatusCodesEnum';

export class CompanyComponent extends Component {
  static displayName = CompanyComponent.name;

  constructor(props) {
    super(props);
    this.state = { company: {}, nip: '' };
  }

  render() {
    return (
      <div>
        <h2 id="tableLabel">Search for companies by NIP</h2>
        <form>
          <div className="mb-3">
            <input
              name='nip'
              type="text"
              className="form-control"
              placeholder='Enter NIP of company'
              value={this.state.nip}
              onChange={this.handleChange} />
          </div>
          <button disabled={this.state.nip === ''} type="submit" className="btn btn-secondary mb-4"
            onClick={(e) => this.loadCompanyDataByNIP(e)}
          >Submit</button>
        </form>
        {
          this.renderCompanyData(this.state.responseStatus, this.state.company)
        }
      </div>
    );
  }

  renderCompanyData(responseStatus, company) {
    switch (responseStatus) {
      case undefined:
        {
          return null;
        }
      case HttpStatusCodesEnum.OK:
        {
          Object.entries(company).filter(e => e[1] === null).forEach((e) => {
            company[e[0]] = '';
          })

          return (
            <div id='companyForm'>
              <div className="form-row">
                <div className="form-group col-md-6">
                  <label htmlFor="companyName">Name</label>
                  <input readOnly type="text" className="form-control" id="companyName" placeholder="Name" value={company.name} />
                </div>
                <div className="form-group col-md-6">
                  <label htmlFor="nip">NIP</label>
                  <input readOnly type="text" className="form-control" id="nip" placeholder="NIP" value={company.nip} />
                </div>
              </div>
              <div className="form-row">
                <div className="form-group col-md-3">
                  <label htmlFor="pesel">PESEL</label>
                  <input readOnly type="text" className="form-control" id="pesel" value={company.pesel} />
                </div>
                <div className="form-group col-md-3">
                  <label htmlFor="regon">REGON</label>
                  <input readOnly type="text" className="form-control" id="regon" placeholder="Apartment, studio, or floor" value={company.regon} />
                </div>
                <div className="form-group col-md-3">
                  <label htmlFor="statusVat">Status VAT</label>
                  <input readOnly type="text" className="form-control" id="statusVat" placeholder="1234 Main St" value={company.statusVat} />
                </div>
                <div className="form-group col-md-3">
                  <label htmlFor="registrationLegalDate">Registration Legal Date</label>
                  <input readOnly type="date" className="form-control" id="registrationLegalDate" value={(moment(company.registrationLegalDate)).format("YYYY-MM-DD")} />
                </div>
              </div>
              <div className="form-row">
                <div className="form-group col-md-6">
                  <label htmlFor="residenceAddress">Residence Address</label>
                  <TextareaAutosize readOnly className="form-control" id="residenceAddress" value={company.residenceAddress} />
                </div>
                <div className="form-group col-md-6">
                  <label htmlFor="workingAddress">Working Address</label>
                  <TextareaAutosize readOnly className="form-control" id="workingAddress" value={company.workingAddress} />
                </div>
              </div>
              <div className="form-group">
                <label htmlFor="representatives">Representatives</label>
                {
                  company.representatives.map((r) => (
                    <li key={company.id + r.firstName + r.lastName}>
                      {r.firstName} {r.lastName}
                    </li>))
                }
              </div>
            </div>
          )
        }
      default:
        {
          return <div>This company was not found.</div>
        }
    }
  }

  async loadCompanyDataByNIP(e) {
    e.preventDefault();
    let comparySearchByNipUrl = `${process.env.REACT_APP_API_URL}/api/search/company/${this.state.nip}`;
    const response = await fetch(comparySearchByNipUrl);
    const data = await response.json();
    this.setState({ responseStatus: response.status, company: data, nip: '' });
  }

  handleChange = (event) => {
    this.setState({ 'nip': event.target.value.replaceAll(/\D/g, '') });
  }
}
