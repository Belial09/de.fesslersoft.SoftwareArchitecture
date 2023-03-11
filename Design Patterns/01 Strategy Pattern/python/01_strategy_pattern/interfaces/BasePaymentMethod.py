from abc import ABC, abstractmethod


class BasePaymentMethod(ABC):

    @classmethod
    def __subclasshook__(cls, subclass):
        return (hasattr(subclass, 'getpaymentmethodname') and
                callable(subclass.getpaymentmethodname))

    @abstractmethod
    def getpaymentmethodname(self):
        """Load in the data set"""
        pass