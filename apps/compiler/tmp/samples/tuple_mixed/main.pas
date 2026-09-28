program SpiralGenerated;
{$mode objfpc}{$H+}

type
  Tuple0 = record
    v1: Single;
    v2: LongInt;
    v0: Boolean;
  end;

function TupleCreate0(v0: Boolean; v1: Single; v2: LongInt): Tuple0;
begin
  Result.v1 := v1;
  Result.v2 := v2;
  Result.v0 := v0;
end;

function method0(v0: Single): Tuple0;
var
  v1: Boolean;
begin
  v1 := (v0 >= 3.5);
  Exit(TupleCreate0(v1, v0, 7));
end;

function method1(v0: Boolean; v1: Single; v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  if v0 then begin
    v3 := (v1 >= 3.5);
    if v3 then begin
      v4 := (v2 - 7);
      Exit(v4);
    end else begin
      Exit(1);
    end;
  end else begin
    Exit(2);
  end;
end;

function SpiralMain: LongInt;
var
  v0: Single;
  v1: Boolean;
  v2: Single;
  v3: LongInt;
  tmp0: Tuple0;
begin
  v0 := 4.0;
  tmp0 := method0(v0);
  v1 := tmp0.v0;
  v2 := tmp0.v1;
  v3 := tmp0.v2;
  Exit(method1(v1, v2, v3));
end;

begin
  Halt(SpiralMain);
end.
