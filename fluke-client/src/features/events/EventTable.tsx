import React from "react";
import { IEvent } from "../../app/models/event";
import { Table } from "semantic-ui-react";
import { EventHeader } from "./EventHeader";
import { EventBody } from "./EventBody";

interface IProps {
  events: IEvent[];
  selectEvent: (enevt: IEvent) => void;
}

export const EventTable: React.FC<IProps> = ({ events, selectEvent }) => {
  return (
    <Table celled>
      <EventHeader />
      <EventBody events={events} selectEvent={selectEvent} />
    </Table>
  );
};
