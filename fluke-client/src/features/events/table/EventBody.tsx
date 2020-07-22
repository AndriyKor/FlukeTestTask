import React from "react";
import { IEvent } from "../../../app/models/event";
import { EventLine } from "./EventLine";
import { Table } from "semantic-ui-react";

interface IProps {
  events: IEvent[];
  selectedEvent: IEvent | null;
  selectEvent: (id: string) => void;
}

export const EventBody: React.FC<IProps> = ({
  events,
  selectedEvent,
  selectEvent,
}) => {
  return (
    <Table.Body>
      {events.map((event) => (
        <EventLine
          key={event.id}
          event={event}
          selectedEvent={selectedEvent}
          selectEvent={selectEvent}
        />
      ))}
    </Table.Body>
  );
};
