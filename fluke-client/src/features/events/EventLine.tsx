import React from "react";
import { IEvent } from "../../app/models/event";
import { Table, Button } from "semantic-ui-react";

interface IProps {
  event: IEvent;
  selectEvent: (event: IEvent) => void;
}

export const EventLine: React.FC<IProps> = ({ event, selectEvent }) => {
  const { id, title, status, category, date } = event;
  return (
    <Table.Row
      key={id}
      onClick={() => selectEvent(event)}
      active={status == "closed" ? true : false}
    >
      <Table.Cell>{title}</Table.Cell>
      <Table.Cell>{status}</Table.Cell>
      <Table.Cell>{category}</Table.Cell>
      <Table.Cell>{date}</Table.Cell>
    </Table.Row>
  );
};
