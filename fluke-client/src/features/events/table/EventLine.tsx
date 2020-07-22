import React from "react";
import { IEvent } from "../../../app/models/event";
import { Table } from "semantic-ui-react";

interface IProps {
  event: IEvent;
  selectedEvent: IEvent | null;
  selectEvent: (id: string) => void;
}

export const EventLine: React.FC<IProps> = ({
  event,
  selectedEvent,
  selectEvent,
}) => {
  const { title, status, category, date } = event;
  return (
    <Table.Row
      onClick={() => selectEvent(event.id)}
      active={status === "closed" ? true : false}
      warning={selectedEvent && selectedEvent.id === event.id ? true : false}
    >
      <Table.Cell>{title}</Table.Cell>
      <Table.Cell>{status}</Table.Cell>
      <Table.Cell>{category}</Table.Cell>
      <Table.Cell>{date}</Table.Cell>
    </Table.Row>
  );
};
