program SpiralGenerated;
{$mode objfpc}{$H+}

function __spiral_scc_method2_method1(__spiral_tail_state: LongInt; v0: LongInt; v1: AnsiString): LongInt;
var
  v2: LongInt;
  v3: Boolean;
  v4: Boolean;
  v5: LongInt;
  __spiral_scc_arg0: LongInt;
  __spiral_scc_arg1: AnsiString;
begin
  while True do begin
    if (__spiral_tail_state = 0) then begin
      v2 := (v0 - 1);
      v3 := (v2 = 0);
      if v3 then begin
        v4 := (7 = 7);
        if v4 then begin
          v5 := Length(v1);
          Exit(v5);
        end else begin
          Exit(99);
        end;
      end else begin
        __spiral_scc_arg0 := v2;
        __spiral_scc_arg1 := v1;
        v0 := __spiral_scc_arg0;
        v1 := __spiral_scc_arg1;
        __spiral_tail_state := 1;
        Continue;
      end;
    end else begin
      v2 := (v0 - 1);
      v3 := (v2 = 0);
      if v3 then begin
        v4 := (11 = 7);
        if v4 then begin
          v5 := Length(v1);
          Exit(v5);
        end else begin
          Exit(99);
        end;
      end else begin
        __spiral_scc_arg0 := v2;
        __spiral_scc_arg1 := v1;
        v0 := __spiral_scc_arg0;
        v1 := __spiral_scc_arg1;
        __spiral_tail_state := 0;
        Continue;
      end;
    end;
  end;
end;

function method2(v0: LongInt; v1: AnsiString): LongInt;
begin
  Exit(__spiral_scc_method2_method1(0, v0, v1));
end;

function method1(v0: LongInt; v1: AnsiString): LongInt;
begin
  Exit(__spiral_scc_method2_method1(1, v0, v1));
end;

function method0(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: Boolean;
  v7: LongInt;
  v3: Boolean;
  v4: LongInt;
  v8: LongInt;
begin
  v2 := (v0 = 0);
  if v2 then begin
    v3 := (7 = 7);
    if v3 then begin
      v4 := Length(v1);
      v7 := v4;
    end else begin
      v7 := 99;
    end;
  end else begin
    v7 := method1(v0, v1);
  end;
  v8 := (v7 - 2);
  Exit(v8);
end;

function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
  v5: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
begin
  v0 := 1000000;
  v1 := (v0 mod 2);
  v2 := (v1 = 0);
  if v2 then begin
    v3 := 'ok';
    v5 := v3;
  end else begin
    v4 := 'go';
    v5 := v4;
  end;
  Exit(method0(v0, v5));
end;

begin
  Halt(SpiralMain);
end.
