﻿import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Modal, Button, Form } from 'semantic-ui-react';

export default class StoreUpdate extends Component {
    constructor(props) {
        super(props);
        this.state = {

        };

        this.onClose = this.onClose.bind(this);
    }

    onClose() {
        this.setState({ showUpdateModel: false });
        window.location.reload()
    }

    render() {
        return (
            <React.Fragment>
                <Modal open={this.props.showUpdateModel} onClose={this.props.onClose} size='small'>
                    <Modal.Header> Edit Store Details </Modal.Header>
                    <Modal.Content>
                        <Form>
                            <Form.Field>
                                <label>Name</label>
                                <input type="text" name="StoreName" placeholder='Name' defaultValue={this.props.Name} onChange={this.props.onChange} />
                                <div style={{ color: 'red' }}>
                                    {this.props.errors.StoreName}
                                </div>
                            </Form.Field>
                            <Form.Field>
                                <label>Address</label>
                                <input type="text" name="StoreAddress" placeholder='Address' defaultValue={this.props.Address} onChange={this.props.onChange} />
                                <div style={{ color: 'red' }}>
                                    {this.props.errors.StoreAddress}
                                </div>
                            </Form.Field>
                        </Form>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button onClick={this.props.onClose} secondary >Cancel
                        </Button>
                        <Button onClick={this.props.onUpdateSubmit} className="ui green button">Edit
                        <i className="check icon"></i>
                        </Button>
                    </Modal.Actions>
                </Modal>
            </React.Fragment>
        )
    }
}