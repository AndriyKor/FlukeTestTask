import React from "react";
import { IEvent } from "../../app/models/event";
import { Table } from "semantic-ui-react";
import { EventHeader } from "./EventHeader";
import { EventBody } from "./EventBody";

interface IProps {
  events: IEvent[];
}

export const EventTable: React.FC<IProps> = ({ events }) => {
  return (
    <Table celled>
      <EventHeader />
      <EventBody events={events} />
    </Table>
  );
};
