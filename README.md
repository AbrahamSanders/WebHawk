# WebHawk

WebHawk is a general-purpose scriptless web automation tool designed to get simple to moderately complex automation tasks up and running quickly.

## How is WebHawk useful?
There are many ways to use WebHawk. A few are listed below:

- **Watch and alert**
WebHawk can be scheduled to monitor a web page for a condition to occur and send a notification when it does.

- **Scrape data**
WebHawk can scrape data from web pages and export it to XML or to a database.

- **Form filling**
WebHawk can fill out forms using data pulled in from a database.

- **Automate navigation**
Save time by recording navigation macros on pages which are not easily linkable.

- **Any combination of the above!**

## How do I work with WebHawk?
WebHawk can either be run in the GUI tool or used directly as a library from your .NET code.
Hosting WebHawk as a windows service is on the roadmap.

## Roadmap
- The automation engine is built on top of the IE browser API. To support other browsers (and for richer xpath support), swap out the IE browser API with Selenium.

- Move the automation engine, scheduler, and database layer to a windows service and simplify the GUI tool to simply communicate with the service.

- Provide canned sequence templates for the most common use-cases

- Provide a plugin interface for running custom .NET code within a step

- Import / Export support for web-based APIs as an alternative to direct database access

- Import / Export support for Excel formats

- Import support for XML

- Add a step type which injects user-written javascript into the page to allow for the creation of scripted or hybrid sequences

- Add a step type which allows the user to initialize state variables with a static value
