from __future__ import annotations
from dataclasses import dataclass
from uuid import UUID, uuid4


@dataclass
class BaseItem:
    name: str
    guid: UUID = uuid4()
