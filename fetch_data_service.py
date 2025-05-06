from flask import Flask, request, jsonify
from datetime import datetime
import time
from polygon import RESTClient

# creating a flask server to listen to calls and provide data
app = Flask(__name__)
client = RESTClient(api_key="API token here - hidden for github")

#converting datetime inputs to unix timestamp to meeet polygon requirements for timestamps
def to_unix_timestamp(dateTime):
    return int(time.mktime(dateTime.timetuple()) * 1000)

# flask endpoint that is called by frontend to fetch data. The endpoint listens to GET calls and responds with market data requested
@app.route("/fetch_data", methods=["GET"])
def fetch_data():
    try:
        symbol = request.args.get("symbol")
        start_time_str = request.args.get("start")
        end_time_str = request.args.get("end")

        if not all([symbol, start_time_str, end_time_str]):
            return jsonify({"error": "Missing query parameters"}), 400

        #converting from string to datetime object
        start_dt = datetime.fromisoformat(start_time_str)
        end_dt = datetime.fromisoformat(end_time_str)

        start_ts = to_unix_timestamp(start_dt)
        end_ts = to_unix_timestamp(end_dt)

        #provides minute by minute stock ticker data for the given time range
        aggs = client.get_aggs(ticker=symbol, multiplier=1, timespan="minute", from_=start_ts, to=end_ts)

        results = []
        if isinstance(aggs, list):
            for entry in aggs:
                timestamp = datetime.fromtimestamp(entry.timestamp / 1000).strftime('%Y-%m-%d %H:%M:%S')
                results.append({
                    "timestamp": timestamp,
                    "open": entry.open,
                    "high": entry.high,
                    "low": entry.low,
                    "close": entry.close,
                    "volume": entry.volume
                })

        return jsonify(results)

    except Exception as e:
        return jsonify({"error": str(e)}), 500

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=8000)
