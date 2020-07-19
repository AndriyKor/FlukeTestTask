import React from "react";
import { IEvent } from "../../app/models/event";
import { Table } from "semantic-ui-react";

interface IProps {
  event: IEvent;
}

export const EventLine: React.FC<IProps> = ({ event }) => {
  const { id, title, status, category, date, closedDate } = event;
  return (
    <Table.Row key={id}>
      <Table.Cell>{title}</Table.Cell>
      <Table.Cell>{status}</Table.Cell>
      <Table.Cell>{category}</Table.Cell>
      <Table.Cell>{date}</Table.Cell>
      <Table.Cell>{closedDate}</Table.Cell>
    </Table.Row>
  );
};
