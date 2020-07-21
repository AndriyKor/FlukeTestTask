import React from "react";
import { IEvent } from "../../app/models/event";
import { Grid } from "semantic-ui-react";
import { EventTable } from "./table/EventTable";
import { EventDetails } from "./EventDetails";

interface IProps {
  events: IEvent[];
  selectedEvent: IEvent | null;
  totalEvents: number;
  currentPage: number;
  pageSize: number;
  selectEvent: (id: string) => void;
  selectPage: (page: number) => void;
}

export const EventGrid: React.FC<IProps> = ({
  events,
  selectedEvent,
  totalEvents,
  currentPage,
  pageSize,
  selectEvent,
  selectPage,
}) => {
  return (
    <Grid>
      <Grid.Column width={10}>
        <EventTable
          events={events}
          totalEvents={totalEvents}
          currentPage={currentPage}
          pageSize={pageSize}
          selectEvent={selectEvent}
          selectPage={selectPage}
        />
      </Grid.Column>
      <Grid.Column width={6}>
        {selectedEvent && <EventDetails event={selectedEvent} />}
      </Grid.Column>
    </Grid>
  );
};
