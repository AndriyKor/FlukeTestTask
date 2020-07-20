import React from "react";
import { IEvent } from "../../app/models/event";
import { Table } from "semantic-ui-react";

interface IProps {
  event: IEvent;
}

export const EventDetails: React.FC<IProps> = ({ event }) => {
  return (
    <Table celled>
      <Table.Header>
        <Table.Row>
          <Table.HeaderCell colSpan="2">{event.title}</Table.HeaderCell>
        </Table.Row>
      </Table.Header>

      <Table.Body>
        <Table.Row>
          <Table.Cell>Id</Table.Cell>
          <Table.Cell>{event.id}</Table.Cell>
        </Table.Row>
        <Table.Row>
          <Table.Cell>Category</Table.Cell>
          <Table.Cell>{event.category}</Table.Cell>
        </Table.Row>
        <Table.Row>
          <Table.Cell>Closed Date</Table.Cell>
          <Table.Cell>{event.closedDate}</Table.Cell>
        </Table.Row>
        <Table.Row>
          <Table.Cell>Link</Table.Cell>
          <Table.Cell>
            <a href={event.link}>{event.link}</a>
          </Table.Cell>
        </Table.Row>
      </Table.Body>
    </Table>
  );
};
