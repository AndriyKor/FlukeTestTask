import React from "react";
import { IEvent } from "../../../app/models/event";
import { EventLine } from "./EventLine";
import { Table } from "semantic-ui-react";

interface IProps {
  events: IEvent[];
  selectEvent: (id: string) => void;
}

export const EventBody: React.FC<IProps> = ({ events, selectEvent }) => {
  return (
    <Table.Body>
      {events.map((event) => (
        <EventLine key={event.id} event={event} selectEvent={selectEvent} />
      ))}
    </Table.Body>
  );
};
