import React, { useState } from "react";
import { IEvent } from "../../app/models/event";
import { Grid } from "semantic-ui-react";
import { EventTable } from "./EventTable";
import { EventDetails } from "./EventDetails";

interface IProps {
  events: IEvent[];
  selectEvent: (event: IEvent) => void;
  selectedEvent: IEvent | null;
}

export const EventGrid: React.FC<IProps> = ({
  events,
  selectEvent,
  selectedEvent,
}) => {
  console.log(selectedEvent);

  return (
    <Grid>
      <Grid.Column width={10}>
        <EventTable events={events} selectEvent={selectEvent} />
      </Grid.Column>
      <Grid.Column width={6}>
        {selectedEvent && <EventDetails event={selectedEvent} />}
      </Grid.Column>
    </Grid>
  );
};
