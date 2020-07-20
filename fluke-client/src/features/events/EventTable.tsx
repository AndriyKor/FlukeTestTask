import React, { useState } from "react";
import { IEvent } from "../../app/models/event";
import { Table } from "semantic-ui-react";
import { EventHeader } from "./EventHeader";
import { EventBody } from "./EventBody";
import { EventFooter } from "./EventFooter";

interface IProps {
  events: IEvent[];
  selectEvent: (enevt: IEvent) => void;
}

export const EventTable: React.FC<IProps> = ({ events, selectEvent }) => {
  const [currentPage, setCurrentPage] = useState<number>(1);

  return (
    <Table celled selectable>
      <EventHeader />
      <EventBody events={events} selectEvent={selectEvent} />
      <EventFooter
        itemsCount={99}
        pageSize={10}
        currentPage={currentPage}
        onPageChange={(page: number) => {
          setCurrentPage(page);
        }}
      />
    </Table>
  );
};
