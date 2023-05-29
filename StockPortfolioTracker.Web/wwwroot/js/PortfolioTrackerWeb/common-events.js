var CommonEvents = CommonEvents || {};

CommonEvents.DispatchChangeEvent = function(element)
{
    const event = new Event("change");
    element.dispatchEvent(event);
};