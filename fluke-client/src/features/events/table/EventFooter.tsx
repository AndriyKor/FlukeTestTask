import React from "react";
import { Table, Menu, Icon } from "semantic-ui-react";
import _ from "lodash";

interface IProps {
  itemsCount: number;
  pageSize: number;
  currentPage: number;
  onPageChange: (page: number) => void;
}

export const EventFooter: React.FC<IProps> = ({
  itemsCount,
  pageSize,
  currentPage,
  onPageChange,
}) => {
  const pagesCount = Math.ceil(itemsCount / pageSize);
  if (pagesCount === 1) return null;
  const pageRange = _.range(1, pagesCount + 1);

  return (
    <Table.Footer>
      <Table.Row>
        <Table.HeaderCell colSpan="4">
          <Menu floated="right" pagination>
            <Menu.Item as="a" icon>
              <Icon name="chevron left" />
            </Menu.Item>
            {pageRange.map((page) => (
              <Menu.Item
                as="a"
                key={page}
                className={page === currentPage ? "active" : ""}
                onClick={() => onPageChange(page)}
              >
                {page}
              </Menu.Item>
            ))}
            <Menu.Item as="a" icon>
              <Icon name="chevron right" />
            </Menu.Item>
          </Menu>
        </Table.HeaderCell>
      </Table.Row>
    </Table.Footer>
  );
};
