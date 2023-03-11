from __future__ import annotations
from interfaces.BaseItem import BaseItem
from uuid import UUID, uuid4


class Item(BaseItem):
    guid: UUID
    name: str

    def __init__(self, name: str) -> None:
        self.guid = uuid4()
        self.name = name