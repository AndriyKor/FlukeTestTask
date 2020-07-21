import React from "react";
import { IEvent } from "../../../app/models/event";
import { Table } from "semantic-ui-react";
import { EventHeader } from "./EventHeader";
import { EventBody } from "./EventBody";
import { EventFooter } from "./EventFooter";

interface IProps {
  events: IEvent[];
  totalEvents: number;
  currentPage: number;
  pageSize: number;
  selectEvent: (id: string) => void;
  selectPage: (page: number) => void;
}

export const EventTable: React.FC<IProps> = ({
  events,
  totalEvents,
  currentPage,
  pageSize,
  selectEvent,
  selectPage,
}) => {
  return (
    <Table celled selectable>
      <EventHeader />
      <EventBody events={events} selectEvent={selectEvent} />
      <EventFooter
        itemsCount={totalEvents}
        pageSize={pageSize}
        currentPage={currentPage}
        onPageChange={selectPage}
      />
    </Table>
  );
};
