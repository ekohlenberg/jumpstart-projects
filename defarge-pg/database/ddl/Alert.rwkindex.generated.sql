
CREATE UNIQUE INDEX rwk_app_alert ON app.alert (alert_rule_id, metric_event_id, triggered_at);


